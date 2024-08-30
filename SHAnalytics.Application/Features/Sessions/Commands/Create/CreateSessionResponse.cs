namespace SHAnalytics.Application.Features.Sessions.Commands.Create
{
    public class CreateSessionResponse
    {
        public int Id { get; set; }
        public int InGameId { get; set; }
        public string SelectedHero { get; set; }
        public string Difficulty { get; set; }
        public int SessionTime { get; set; }
        public string EndCause { get; set; }
        public string DeathCause { get; set; }
    }
}
