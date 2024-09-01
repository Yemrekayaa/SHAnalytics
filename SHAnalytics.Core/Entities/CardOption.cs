namespace SHAnalytics.Core.Entities
{
    public class CardOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BattleId { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPerma { get; set; }
        public Battle Battle { get; set; }

    }
}
