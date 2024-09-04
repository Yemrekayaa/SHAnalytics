using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;
using SHAnalytics.Infrastructure.Data;

namespace SHAnalytics.Infrastructure.Repositories
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly AppDbContext _context;

        public DifficultyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Difficulty>> GetListBySessionAsync(int sessionId)
        {
            return await _context.Difficulties.Where(x => x.SessionId == sessionId).ToListAsync();
        }
    }
}
