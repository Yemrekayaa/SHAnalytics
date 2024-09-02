namespace SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattleArea
{
    public class GetListByBattleAreaCardOptionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BattleId { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPerma { get; set; }
    }
}
