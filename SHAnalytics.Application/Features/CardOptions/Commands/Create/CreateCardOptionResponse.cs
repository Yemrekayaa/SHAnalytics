namespace SHAnalytics.Application.Features.CardOptions.Commands.Create
{
    public class CreateCardOptionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BattleId { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPerma { get; set; }

    }
}
