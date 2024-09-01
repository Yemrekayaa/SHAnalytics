namespace SHAnalytics.Core.Entities
{
    public class BattleArea
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public Session Session { get; set; }
        public ICollection<Battle> Battles { get; set; }
    }
}
