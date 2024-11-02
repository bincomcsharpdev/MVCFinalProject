using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Repositories.Interfaces
{
    public interface IPortfolioItemRepository : IRepository<YahyaPortfolioItem>
    {
        Task<IEnumerable<YahyaPortfolioItem>> GetPortfolioItemsByUserIdAsync(Guid userId);
    }
}
