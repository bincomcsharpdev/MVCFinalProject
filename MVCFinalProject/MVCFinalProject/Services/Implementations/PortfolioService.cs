using AutoMapper;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Repositories.Interfaces;
using MVCFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MVCFinalProject.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioItemRepository _portfolioItemRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public PortfolioService(IPortfolioItemRepository portfolioItemRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _portfolioItemRepository = portfolioItemRepository;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<IEnumerable<PortfolioItemDto>> GetAllPortfolioItemsAsync()
        {
            var portfolioItems = await _portfolioItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PortfolioItemDto>>(portfolioItems);
        }

        public async Task<PortfolioItemDto?> GetPortfolioItemByIdAsync(Guid id)
        {
            var portfolioItem = await _portfolioItemRepository.GetByIdAsync(id);
            return _mapper.Map<PortfolioItemDto>(portfolioItem);
        }

        public async Task<IEnumerable<PortfolioItemDto>> GetUserPortfolioItemsAsync(Guid userId)
        {
            var portfolioItems = await _portfolioItemRepository.GetPortfolioItemsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PortfolioItemDto>>(portfolioItems);
        }

        public async Task AddPortfolioItemAsync(PortfolioItemDto portfolioItemDto, Guid userId, IFormFile? file)
        {
            var portfolioItem = _mapper.Map<YahyaPortfolioItem>(portfolioItemDto);
            portfolioItem.UserId = userId;
            portfolioItem.DateCreated = DateTime.UtcNow;

            if (file != null)
            {
                portfolioItem.FilePath = await SaveFileAsync(file);
            }

            await _portfolioItemRepository.AddAsync(portfolioItem);
            
        }

        public async Task<bool> SavePortfolioItemAsync(PortfolioItemDto portfolioItemDto, Guid userId, IFormFile file)
        {
            try
            {
                portfolioItemDto.UserId = userId;

                if (file != null)
                {
                    portfolioItemDto.FilePath = await SaveFileAsync(file);
                }

                var portfolioItem = _mapper.Map<YahyaPortfolioItem>(portfolioItemDto);

                await _portfolioItemRepository.AddAsync(portfolioItem);

                return true; 
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error saving portfolio item: {ex.Message}");
                return false; 
            }
        }


        public async Task UpdatePortfolioItemAsync(Guid id, PortfolioItemDto portfolioItemDto, IFormFile? file)
        {
            var portfolioItem = await _portfolioItemRepository.GetByIdAsync(id);
            if (portfolioItem == null) throw new KeyNotFoundException("Portfolio item not found");

            _mapper.Map(portfolioItemDto, portfolioItem);

            if (file != null)
            {
                // Delete the old file if exists
                if (!string.IsNullOrEmpty(portfolioItem.FilePath))
                {
                    DeleteFile(portfolioItem.FilePath);
                }

                portfolioItem.FilePath = await SaveFileAsync(file);
            }

            await _portfolioItemRepository.UpdateAsync(portfolioItem);


        }

        public async Task<bool> DeletePortfolioItemAsync(Guid id)
        {
            try
            {
                var portfolioItem = await _portfolioItemRepository.GetByIdAsync(id);
                if (portfolioItem == null) return false;

                // Optional: Delete associated file
                if (!string.IsNullOrEmpty(portfolioItem.FilePath))
                {
                    DeleteFile(portfolioItem.FilePath);
                }

                await _portfolioItemRepository.DeleteAsync(portfolioItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadPath);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return Path.Combine("uploads", uniqueFileName);  // Save relative path
        }

        private void DeleteFile(string relativeFilePath)
        {
            var filePath = Path.Combine(_environment.WebRootPath, relativeFilePath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
