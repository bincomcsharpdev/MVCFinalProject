using MVCFinalProject.Models.DTOs;

namespace MVCFinalProject.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<IEnumerable<PortfolioItemDto>> GetAllPortfolioItemsAsync();
        Task<PortfolioItemDto?> GetPortfolioItemByIdAsync(Guid id);
        Task<IEnumerable<PortfolioItemDto>> GetUserPortfolioItemsAsync(Guid userId);
        Task AddPortfolioItemAsync(PortfolioItemDto portfolioItemDto, Guid userId, IFormFile? file);

        Task UpdatePortfolioItemAsync(Guid id, PortfolioItemDto portfolioItemDto, IFormFile? file);
        Task<bool> SavePortfolioItemAsync(PortfolioItemDto portfolioItemDto, Guid userId, IFormFile file);
        Task<bool> DeletePortfolioItemAsync(Guid id);
        
    }
}

