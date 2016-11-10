using System;

using ServiceStack.DataAnnotations;

namespace RaceParty.RaceControl.ServiceModel
{
    public class LapTime
    {
        [AutoIncrement]
        public long Id { get; set; }
        public string TrackName { get; set; }
        public string CarName { get; set; }
        public string CarClass { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime CreatedAt { get; set; }

        public string DriverName { get; set; }
        public string Hostname { get; set; }

        [Ignore]
        public FlagMan RecordedBy { get; set; }
    }
}