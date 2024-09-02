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
        public async Task<IEnumerable<CardOption>> GetListByBattleAreaIdAsync(int battleAreaId)
        {
            return await _context.CardOptions.Include(co => co.Battle)
                .ThenInclude(b => b.BattleArea)
                .Where(co => co.Battle.BattleArea.Id == battleAreaId)
                .ToListAsync();
        }
        public async Task<IEnumerable<CardOption>> GetListByBattleIdAsync(int battleId)
        {
            return await _context.CardOptions.Include(co => co.Battle)
                .Where(co => co.Battle.Id == battleId)
                .ToListAsync();
        }
    }
}
