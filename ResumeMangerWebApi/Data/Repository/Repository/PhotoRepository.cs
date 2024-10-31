using Microsoft.EntityFrameworkCore;
using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data.Repository.Repository
{
    public class PhotoRepository(ApplicationDbContext context) : IPhotoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeletePhoto(int id)
        {
            var photo = await _context.Anthonia_Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Anthonia_Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Anthonia_Photo> GetPhotoById(int id)
        {
            return await _context.Anthonia_Photos.FindAsync(id);
        }

        public async Task<IEnumerable<Anthonia_Photo>> GetPhotos(int page, int pageSize)
        {
            return await _context.Anthonia_Photos
                 .OrderBy(p => p.Id)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
        }

        public async Task UpdatePhoto(Anthonia_Photo photo)
        {
            _context.Anthonia_Photos.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UploadPhoto(Anthonia_Photo photo)
        {
            await _context.Anthonia_Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
        }
    }
}
