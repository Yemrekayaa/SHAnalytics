using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;
using SHAnalytics.Infrastructure.Data;

namespace SHAnalytics.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetListByInGameIdAsync(int inGameId)
        {
            var data = await _context.Sessions.Where(s => s.InGameId == inGameId).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Session>> GetListByPlayerIdAsync(int playerId)
        {

            var data = await _context.Sessions.Include(s => s.InGame)
                .ThenInclude(ig => ig.Player)
                .Where(s => s.InGame.Player.Id == playerId)
                .ToListAsync();
            return data;
        }
    }
}
