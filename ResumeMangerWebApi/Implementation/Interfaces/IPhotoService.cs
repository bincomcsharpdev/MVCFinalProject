using ResumeMangerWebApi.Entities;
using ResumeMangerWebApi.Model;

namespace ResumeMangerWebApi.Implementation.Interfaces
{
    public interface IPhotoService
    {
        Task UploadPhoto(PhotoUpload upload);
        Task<Anthonia_Photo> GetPhotoById(int id);
        Task<IEnumerable<Anthonia_Photo>> GetAllPhotos(int page, int pageSize);
        Task UpdatePhoto(int id, Anthonia_Photo updatedPhoto);
        Task DeletePhoto(int id);
    }
}
