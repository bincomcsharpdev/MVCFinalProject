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
            var photo = await _context.Anthonia_Photohs.FindAsync(id);
            if (photo != null)
            {
                _context.Anthonia_Photohs.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Anthonia_Photoh> GetPhotoById(int id)
        {
            return await _context.Anthonia_Photohs.FindAsync(id);
        }

        public async Task<IEnumerable<Anthonia_Photoh>> GetPhotos(int page, int pageSize)
        {
            return await _context.Anthonia_Photohs
                 .OrderBy(p => p.Id)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
        }

        public async Task UpdatePhoto(Anthonia_Photoh photo)
        {
            _context.Anthonia_Photohs.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UploadPhoto(Anthonia_Photoh photo)
        {
            await _context.Anthonia_Photohs.AddAsync(photo);
            await _context.SaveChangesAsync();
        }
    }
}
