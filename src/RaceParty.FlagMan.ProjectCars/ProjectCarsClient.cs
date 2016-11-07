using System;
using System.Net;

using Microsoft.Extensions.Logging;

using ServiceStack;

namespace RaceParty.FlagMan.ProjectCars
{
    public class ProjectCarsClient
    {
        public string _url;

        private readonly ILogger Log;

        public ProjectCarsClient(string baseUrl, ILoggerFactory logFactory)
        {
            _url = baseUrl;
            Log = logFactory.CreateLogger<ProjectCarsClient>();
        }

        public ProjectCarsResponse GetTimings()
        {
            try
            {
                var responseJson = $"{_url}?timings=true&eventInformation=true&vehicleInformation=true".GetJsonFromUrl();
                
                var response = responseJson.FromJson<ProjectCarsResponse>();
                response.EventInformation.MTrackLocation = response.EventInformation.MTrackLocation.Replace('�', 'ü');

                return response;
            }
            catch (WebException exception)
            {
                Log.LogError($"Error getting Project Cars data: {exception.Message}");
                return null;
            }
        }
    }
}