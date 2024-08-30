namespace SHAnalytics.Core.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int InGameId { get; set; }
        public string SelectedHero { get; set; }
        public string Difficulty { get; set; }
        public int SessionTime { get; set; }
        public string EndCause { get; set; }
        public string DeathCause { get; set; }
        public InGame InGame { get; set; }
    }
}
