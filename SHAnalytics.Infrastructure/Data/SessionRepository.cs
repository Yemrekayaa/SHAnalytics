using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Infrastructure.Data
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Session>> GetListByPlayerIdAsync(int playerId)
        {
            //return await _context.Sessions.Where(s => s.PlayerId == playerId).ToListAsync();
            return null;
        }
    }
}
