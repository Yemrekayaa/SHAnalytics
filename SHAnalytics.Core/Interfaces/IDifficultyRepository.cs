using SHAnalytics.Core.Entities;

namespace SHAnalytics.Core.Interfaces
{
    public interface IDifficultyRepository
    {
        Task<IEnumerable<Difficulty>> GetListBySessionAsync(int sessionId);
    }
}
