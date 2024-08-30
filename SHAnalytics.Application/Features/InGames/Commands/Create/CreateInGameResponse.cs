namespace SHAnalytics.Application.Features.InGames.Commands.Create
{
    public class CreateInGameResponse
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public float GameVersion { get; set; }
    }
}
