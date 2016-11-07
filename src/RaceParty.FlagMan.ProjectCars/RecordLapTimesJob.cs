using System;

using FluentScheduler;

using Microsoft.Extensions.Logging;

using RaceParty.RaceControl.ServiceModel;

namespace RaceParty.FlagMan.ProjectCars
{
    public class RecordLapTimesJob : IJob
    {
        private readonly RecordLapTimesJobState _jobState;

        private readonly RaceControlClient _raceControlClient;

        private static ILogger Log;
        private readonly ProjectCarsClient _client;

        private ProjectCarsResponse _previous;

        private int number = 0;

        public RecordLapTimesJob(ILoggerFactory logFactory, RecordLapTimesJobState jobState, RaceControlClient raceControlClient)
        {
            _jobState = jobState;
            _raceControlClient = raceControlClient;
            Log = logFactory.CreateLogger<RecordLapTimesJob>();
            _client = new ProjectCarsClient("http://10.0.0.222:8080/crest/v1/api", logFactory);
        }

        public void Execute()
        {
            Log.LogDebug("Executing RecordLapTimesJob");
                
            var response = _client.GetTimings();

            if (response == null)
            {
                Log.LogWarning("No response retrieved from PCARS API, skipping this run..");
                return;
            }

            // it's a valid lap.
            if (response.Timings.MLastLapTime != _jobState.Previous.Timings.MLastLapTime)
            {
                // we have a different last lap time -> cogratulation! better time!
                if (!_jobState.Previous.Timings.MLapInvalidated)
                {
                    var time = TimeSpan.FromSeconds(response.Timings.MLastLapTime);

                    Log.LogInformation($"Finished Lap: {time}");

                    _raceControlClient.PublishLapTime(new LapTime()
                                                          {
                                                              Time = time,
                                                              CarClass = response.VehicleInformation.MCarName,
                                                              CarName = response.VehicleInformation.MCarClassName,
                                                              CreatedAt = DateTime.UtcNow,
                                                              RecordedBy = new RaceControl.ServiceModel.FlagMan()
                                                                               {
                                                                                   Driver = "",
                                                                                   HostName = Environment.MachineName,
                                                                               },
                                                              TrackName = response.EventInformation.MTrackLocation + " " + response.EventInformation.MTrackVariation
                                                          });
                }
                else
                {
                    // laptime invalidated :(
                    Log.LogInformation("Lap was invalidated, try harder!!");
                }
            }

            _jobState.Previous = response;
        }
    }
}