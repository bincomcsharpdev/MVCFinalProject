using ProjectAPIs.Model;

namespace ProjectAPIs.Interfaces
{
    public interface IGalleryService
    {
        Task<Gallery> AddPhotos(Gallery gallery);
        Task<Gallery?> GetPhoto(int id);
        Task<bool> DeletePhoto(int id);  
    }
}
