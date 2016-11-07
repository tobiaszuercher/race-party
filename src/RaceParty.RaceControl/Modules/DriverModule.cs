using System.Linq;

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using Raven.Abstractions.Logging;

using ServiceStack;

namespace RaceParty.RaceControl
{
    public class DriverModule : NancyModule
    {
        private Raven.Client.IDocumentSession _session;

        private static ILogger Log;

        public DriverModule(Raven.Client.IDocumentSession session, ILoggerFactory logFactory)
        {
            _session = session;
            Log = logFactory.CreateLogger<DriverModule>();

            Get("/drivers",
                args =>
                {
                    return _session.Query<LapTime>().ToList();
                });

            Post("/driver/register", _ =>
            {
                var body = Request.Body.AsString();
                var request = body.FromJson<Driver>();

                var driver = session.Query<Driver>().Where(d => d.Hostname == request.Hostname).FirstOrDefault();

                if (driver == null)
                {
                    Log.LogInformation($"Register driver {driver.Name} for {driver.Hostname}.");
                    session.Store(driver);
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
            });

            Post("/driver/deregister",
                _ =>
                    {
                        var body = Request.Body.AsString();
                        var request = body.FromJson<Driver>();

                        var driver = session.Query<Driver>().Where(d => d.Hostname == request.Hostname).FirstOrDefault();

                        if (driver != null)
                        {
                            Log.LogInformation($"{driver.Name} deregistered.");
                            session.Delete(driver);

                            return HttpStatusCode.OK;
                        }
                        else
                        {
                            Log.LogInformation($"{driver.Name} deregistered but no driver found.");
                            return HttpStatusCode.NotModified;
                        }
                    });
        }
    }
}