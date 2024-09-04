namespace SHAnalytics.Core.Entities
{
    public class Difficulty
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Name { get; set; }
        public Session Session { get; set; }
    }
}
