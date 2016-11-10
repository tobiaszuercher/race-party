using System.Linq;

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace RaceParty.RaceControl.Modules
{
    public class DriverModule : NancyModule
    {
        private static ILogger Log;

        public DriverModule(IDbConnectionFactory dbFactory, ILoggerFactory logFactory)
        {
            Log = logFactory.CreateLogger<DriverModule>();

            Get("/drivers",
                args =>
                {
                    using (var db = dbFactory.Open())
                    {
                        return db.Select<Driver>();
                    }
                });

            Post("/drivers", _ =>
            {
                var body = Request.Body.AsString();
                var request = body.FromJson<Driver>();

                using (var db = dbFactory.Open())
                {
                    var driver = db.Select<Driver>(d => d.Hostname == request.Hostname).FirstOrDefault();

                    if (driver == null)
                    {
                        Log.LogInformation($"Register driver {request.Name} for {request.Hostname}.");
                        db.Insert(request);

                        return HttpStatusCode.Created;
                    }
                    else
                    {
                        Log.LogInformation($"Change driver to {driver.Name} for {driver.Hostname}.");
                        driver.Name = request.Name;

                        db.Update(driver);

                        return HttpStatusCode.OK;
                    }
                }
            });

            Delete("/drivers/{hostname}",
                parameters =>
                    {
                        var hostnameString = (string)parameters.hostname;

                        using (var db = dbFactory.Open())
                        {
                            var driver = db.Select<Driver>(d => d.Hostname == hostnameString).FirstOrDefault();

                            if (driver != null)
                            {
                                Log.LogInformation($"{driver.Name} went offline.");
                                db.Delete<Driver>(d => d.Hostname == driver.Hostname);

                                return HttpStatusCode.OK;
                            }
                            else
                            {
                                Log.LogInformation($"{hostnameString} went offline but no driver found.");
                                return HttpStatusCode.NotModified;
                            }
                        }
                    });
        }
    }
}