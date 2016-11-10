using System.Linq;

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using Raven.Abstractions.Logging;

using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace RaceParty.RaceControl
{
    public class DriverModule : NancyModule
    {
        private Raven.Client.IDocumentSession _session;

        private static ILogger Log;

        public DriverModule(IDbConnectionFactory dbFactory, ILoggerFactory logFactory, Raven.Client.IDocumentSession session)
        {
            _session = session;
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
                        session.Store(request);
                        session.SaveChanges();

                        return HttpStatusCode.Created;
                    }
                    else
                    {
                        Log.LogInformation($"Change driver to {driver.Name} for {driver.Hostname}.");
                        driver.Name = request.Name;
                        session.SaveChanges();

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
                                session.Delete(driver);
                                session.SaveChanges();

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