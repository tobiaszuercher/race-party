using System;

namespace RaceParty.RaceControl.ServiceModel
{
    public class LapTime
    {
        public long Id { get; set; }
        public string TrackName { get; set; }
        public string CarName { get; set; }
        public string CarClass { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime CreatedAt { get; set; }

        public FlagMan RecordedBy { get; set; }
    }
}