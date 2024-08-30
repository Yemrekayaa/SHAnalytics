namespace SHAnalytics.Application.Features.InGames.Queries.GetList
{
    public class GetListInGameResponse
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public float GameVersion { get; set; }
    }
}
