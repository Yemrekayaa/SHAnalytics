namespace SHAnalytics.Core.Entities
{
    public class InGame
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public float GameVersion { get; set; }
        public Player Player { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
