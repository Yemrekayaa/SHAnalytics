namespace SHAnalytics.Core.Entities
{
    public class Battle
    {
        public int Id { get; set; }
        public int BattleAreaId { get; set; }
        public int BattleNumber { get; set; }
        public BattleArea BattleArea { get; set; }
        public ICollection<CardOption> CardOptions { get; set; }
    }
}
