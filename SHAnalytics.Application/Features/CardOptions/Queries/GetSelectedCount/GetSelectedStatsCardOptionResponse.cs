namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedStatsCardOptionResponse
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int Selected { get; set; }
        public int Perma { get; set; }
        public int PermaSelected { get; set; }
        public int TempSelected { get; set; }
    }
}
