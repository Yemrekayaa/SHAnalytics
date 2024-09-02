using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Infrastructure.Data
{
    public class CardOptionRepository : ICardOptionRepository
    {
        private readonly AppDbContext _context;

        public CardOptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CardOption>> GetListBySessionIdAsync(int sessionId)
        {
            return await _context.CardOptions.Include(co => co.Battle)
                .ThenInclude(b => b.BattleArea)
                .ThenInclude(ba => ba.Session)
                .Where(co => co.Battle.BattleArea.Session.Id == sessionId)
                .ToListAsync();
        }
    }
}
