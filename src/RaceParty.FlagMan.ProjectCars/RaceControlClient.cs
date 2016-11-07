using System;
using System.Net;

using Microsoft.Extensions.Logging;

using RaceParty.RaceControl.ServiceModel;

using ServiceStack;
using ServiceStack.Text;

namespace RaceParty.FlagMan.ProjectCars
{
    public class RaceControlClient
    {
        private string _baseUrl;

        private readonly ILogger Log;

        public RaceControlClient(string baseUrl, ILoggerFactory loggerFactory)
        {
            _baseUrl = baseUrl;
            Log = loggerFactory.CreateLogger<RaceControlClient>();

            JsConfig.DateHandler = DateHandler.ISO8601;
        }

        public void PublishLapTime(LapTime lapTime)
        {
            try
            {
                (_baseUrl + "/laptimes").PostJsonToUrl(lapTime);
            }
            catch (WebException e)
            {
                Log.LogError("Failed to send lap time: " + e.Message);
            }
        }   
    }
}