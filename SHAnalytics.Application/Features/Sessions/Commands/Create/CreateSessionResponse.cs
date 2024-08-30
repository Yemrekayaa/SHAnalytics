namespace SHAnalytics.Application.Features.Sessions.Commands.Create
{
    public class CreateSessionResponse
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int SessionTime { get; set; }
        public string Difficulty { get; set; }
    }
}
