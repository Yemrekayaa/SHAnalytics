using SHAnalytics.Core.Entities;

namespace SHAnalytics.Core.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetListByPlayerIdAsync(int playerId);
    }
}
