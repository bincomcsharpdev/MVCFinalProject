using FinalAssProject.Data;
using FinalAssProject.Interfaces;
using FinalAssProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssProject.Repositories
{
    public class GalleryService : IGalleryService
    {
        private readonly AppDbContext _appContext;

        public GalleryService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<bool> DeleteImage(int id)
        {
            var image = await _appContext.Ken_Galleries.FindAsync(id);
            if (image == null)
                return false;

            _appContext.Ken_Galleries.Remove(image);
            await _appContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Gallery>> GetAllImageItemsAsync()
        {
            return await _appContext.Ken_Galleries.ToListAsync();
        }

        public async Task<Gallery> UploadImageAsync(IFormFile imageFile, string title, string description)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid image file");
            }

            Gallery image;
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);

                image = new Gallery
                {
                    Title = title,
                    Description = description,
                    ImageMimeType = imageFile.ContentType,
                    ImageData = memoryStream.ToArray()

                };
                await _appContext.Ken_Galleries.AddAsync(image);
                await _appContext.SaveChangesAsync();

            }
            return image;
        }
    }
}
