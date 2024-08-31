using SHAnalytics.Core.Entities;

namespace SHAnalytics.Core.Interfaces
{
    public interface IInGameRepository
    {
        Task<IEnumerable<InGame>> GetListByPlayerIdAsync(int playerId);
    }
}
