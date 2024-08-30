using SHAnalytics.Application.Features.Players.Queries.GetList;

namespace SHAnalytics.Application.Features.Sessions.Queries.GetList
{
    public class GetByIdSessionResponse
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int SessionTime { get; set; }
        public string Difficulty { get; set; }

        public static implicit operator GetByIdSessionResponse(GetByIdPlayerResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
