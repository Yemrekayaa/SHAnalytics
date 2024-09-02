using SHAnalytics.Core.Entities;

namespace SHAnalytics.Core.Interfaces
{
    public interface ICardOptionRepository
    {
        Task<IEnumerable<CardOption>> GetListBySessionIdAsync(int sessionId);
    }
}
