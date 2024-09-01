namespace SHAnalytics.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Name { get; set; }
        public bool isPerma { get; set; }
        public string Choosen { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
    }
}
