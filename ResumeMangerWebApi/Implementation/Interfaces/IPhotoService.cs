using ResumeMangerWebApi.Entities;
using ResumeMangerWebApi.DTO;

namespace ResumeMangerWebApi.Implementation.Interfaces
{
    public interface IPhotoService
    {
        Task UploadPhoto(PhotoUploadDto upload);
        Task<Anthonia_Photoh> GetPhotoById(int id);
        Task<IEnumerable<Anthonia_Photoh>> GetAllPhotos(int page, int pageSize);
        Task UpdatePhoto(int id, Anthonia_Photoh updatedPhoto);
        Task DeletePhoto(int id);
    }
}
