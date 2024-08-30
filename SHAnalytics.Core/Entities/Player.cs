namespace SHAnalytics.Core.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTime { get; set; }
        public int TotalPlayed { get; set; }
        public DateTime CreateTime { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
