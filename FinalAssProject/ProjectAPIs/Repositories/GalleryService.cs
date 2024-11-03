using ProjectAPIs.Data;
using ProjectAPIs.Interfaces;
using ProjectAPIs.Model;

namespace ProjectAPIs.Repositories
{
    public class GalleryService : IGalleryService
    {
        private readonly PortfolioContext _portfolioContext;

        public GalleryService(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public async Task<Gallery> AddPhotos(Gallery gallery)
        {
            await _portfolioContext.Ken_Galleries.AddAsync(gallery);
            await _portfolioContext.SaveChangesAsync();
            return gallery;
        }

        public async Task<bool> DeletePhoto(int id)
        {
            var photo = await _portfolioContext.Ken_Galleries.FindAsync(id);
            if (photo == null)
                return false;

            _portfolioContext.Ken_Galleries.Remove(photo);
            await _portfolioContext.SaveChangesAsync();
            return true;
            
        }

        public async Task<Gallery?> GetPhoto(int id)
        {
            var photo = await _portfolioContext.Ken_Galleries.FindAsync(id);
            return photo;
        }
    }
}
