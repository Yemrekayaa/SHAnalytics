namespace SHAnalytics.Application.Features.CardOptions.Queries.GetList
{
    public class GetByIdCardOptionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BattleId { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPerma { get; set; }

    }
}
