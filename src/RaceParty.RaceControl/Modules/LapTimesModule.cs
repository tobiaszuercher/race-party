using System.Linq;

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using Raven.Client;

using ServiceStack;

namespace RaceParty.RaceControl
{
    public class LapTimesModule : NancyModule
    {
        private IDocumentSession _session;

        private static ILogger Log;

        public LapTimesModule(IDocumentSession session, ILoggerFactory loggerFactory)
        {
            _session = session;
            Log = loggerFactory.CreateLogger<LapTimesModule>();

            Get("/laptimes",
                args =>
                    {
                        return _session.Query<LapTime>().ToList();
                    });

            Post("/laptimes", args =>
            {
                var body = Request.Body.AsString();
                var laptime = body.FromJson<LapTime>();

                var driver = session.Query<Driver>().Where(d => d.Hostname == laptime.RecordedBy.HostName).FirstOrDefault();

                if (driver != null)
                {
                    laptime.RecordedBy.Driver = driver.Name;
                }
                else
                {
                    Log.LogWarning($"No driver found for {driver.Hostname}");
                }

                Log.LogInformation($"Storing laptime {laptime.Time} for {driver.Name} ({driver.Hostname})");

                session.Store(laptime);
                session.SaveChanges();

                return HttpStatusCode.Created;
            });
        }
    }
}