using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Infrastructure.Data
{
    public class InGameRepository : IInGameRepository
    {
        private readonly AppDbContext _context;

        public InGameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InGame>> GetListByPlayerIdAsync(int playerId)
        {
            return await _context.InGames.Where(s => s.PlayerId == playerId).ToListAsync();
        }
    }
}
