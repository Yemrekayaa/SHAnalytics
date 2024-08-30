namespace SHAnalytics.Core.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int SessionTime { get; set; }
        public string Difficulty { get; set; }

        public Player Player { get; set; }
    }
}
