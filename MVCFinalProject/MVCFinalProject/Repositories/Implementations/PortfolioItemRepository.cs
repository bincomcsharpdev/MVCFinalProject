using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Repositories.Interfaces;

namespace MVCFinalProject.Repositories.Implementations
{
    public class PortfolioItemRepository : Repository<YahyaPortfolioItem>, IPortfolioItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<YahyaPortfolioItem>> GetPortfolioItemsByUserIdAsync(Guid userId)
        {
            return await _context.YahyaPortfolioItems.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
