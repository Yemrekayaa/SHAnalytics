namespace SHAnalytics.Application.Features.Players.Commands.Create
{
    public class CreatePlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TotalTime { get; set; }
        public int TotalPlayed { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
