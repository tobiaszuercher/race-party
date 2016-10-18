using System;

namespace RaceParty.RaceControl.Model
{
    public class FlagMan
    {
        public Guid Id { get; set; }
        public string HostName { get; set; }
        public DateTime LastSeen { get; set; }
        public string CurrentDriver { get; set; }
    }

    public class LapTime
    {
        public long Id { get; set; }
        public string TrackName { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Sector1 { get; set; }
        public TimeSpan Sector2 { get; set; }
        public TimeSpan Sector3 { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}