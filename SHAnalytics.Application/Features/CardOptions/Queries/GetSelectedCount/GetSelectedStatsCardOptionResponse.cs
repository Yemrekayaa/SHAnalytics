namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedStatsCardOptionResponse
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int TotalSelected { get; set; }
        public int TotalSelectionRate { get; set; }
        public int Temp { get; set; }
        public int TempSelected { get; set; }
        public int TempSelectionRate { get; set; }
        public int Perma { get; set; }
        public int PermaSelected { get; set; }
        public int PermaSelectionRate { get; set; }

    }
}
