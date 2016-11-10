using System.Linq;

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace RaceParty.RaceControl
{
    public class LapTimesModule : NancyModule
    {
        private static ILogger Log;

        public LapTimesModule(ILoggerFactory loggerFactory, IDbConnectionFactory dbConnectionFactory)
        {
            Log = loggerFactory.CreateLogger<LapTimesModule>();

            Get("/laptimes",
                args =>
                    {
                        using (var db = dbConnectionFactory.Open())
                        {
                            return db.Select<LapTime>().OrderBy(lap => lap.TrackName).ThenBy(lap => lap.Time);
                        }
                    });

            Post("/laptimes", args =>
            {
                var body = Request.Body.AsString();
                var laptime = body.FromJson<LapTime>();
                
                using (var db = dbConnectionFactory.Open())
                {
                    var driver = db.Select<Driver>(d => d.Hostname == laptime.Hostname).FirstOrDefault();

                    if (driver != null)
                    {
                        laptime.DriverName = driver.Name;
                    }
                    else
                    {
                        laptime.DriverName = "unknown";
                        Log.LogWarning($"No driver found for {driver.Hostname}");
                    }

                    Log.LogInformation($"Storing laptime {laptime.Time} for {driver.Name} ({driver.Hostname})");

                    db.Insert(laptime);

                    return HttpStatusCode.Created;
                }
            });
        }
    }
}