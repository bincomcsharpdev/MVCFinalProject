using FinalAssProject.Models;

namespace FinalAssProject.Interfaces
{
    public interface IGalleryService
    {
        Task<Gallery> UploadImageAsync(IFormFile imageFile, string title, string description);
        Task<List<Gallery>> GetAllImageItemsAsync();
        Task<bool> DeleteImage(int id);
    }
}
