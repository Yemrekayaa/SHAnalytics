namespace SHAnalytics.Application.Features.Players.Queries.GetList
{
    public class GetByIdPlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TotalTime { get; set; }
        public int TotalPlayed { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
