using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Entities;
using ResumeMangerWebApi.Implementation.Interfaces;
using ResumeMangerWebApi.Model;

namespace ResumeMangerWebApi.Implementation.Services
{
    public class PhotoService(IPhotoRepository photoRepository) : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository = photoRepository;

        public async Task DeletePhoto(int id)
        {
            await _photoRepository.DeletePhoto(id);
        }

        public async Task<IEnumerable<Anthonia_Photo>> GetAllPhotos(int page, int pageSize)
        {
            return await _photoRepository.GetPhotos(page, pageSize);
        }

        public async Task<Anthonia_Photo> GetPhotoById(int id)
        {
            return await _photoRepository.GetPhotoById(id);
        }

        public async Task UpdatePhoto(int id, Anthonia_Photo updatedPhoto)
        {
            var existingPhoto = await _photoRepository.GetPhotoById(id);
            if (existingPhoto != null)
            {
                existingPhoto.Title = updatedPhoto.Title ?? existingPhoto.Title;
                existingPhoto.Description = updatedPhoto.Description ?? existingPhoto.Description;
                await _photoRepository.UpdatePhoto(existingPhoto);

            }
        }

        public async Task UploadPhoto(PhotoUpload upload)
        {
            using var memoryStream = new MemoryStream();
            await upload.File.CopyToAsync(memoryStream);
            var photo = new Anthonia_Photo
            {
                Title = upload.Title,
                Description = upload.Description,
                ImageMimeType = upload.File.ContentType,
                ImageData = memoryStream.ToArray()
            };
            await _photoRepository.UploadPhoto(photo);
        }
    }
}
