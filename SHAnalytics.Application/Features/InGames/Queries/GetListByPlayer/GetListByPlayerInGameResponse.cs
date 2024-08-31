namespace SHAnalytics.Application.Features.Sessions.Queries.GetList
{
    public class GetListByPlayerInGameResponse
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public float GameVersion { get; set; }

    }
}
