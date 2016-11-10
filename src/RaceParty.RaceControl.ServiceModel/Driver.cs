using ServiceStack.DataAnnotations;

namespace RaceParty.RaceControl.ServiceModel
{
    public class Driver
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hostname { get; set; }
    }
}