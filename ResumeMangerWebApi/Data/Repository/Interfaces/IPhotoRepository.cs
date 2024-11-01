using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task UploadPhoto(Anthonia_Photoh photo);
        Task<Anthonia_Photoh> GetPhotoById(int id);
        Task<IEnumerable<Anthonia_Photoh>> GetPhotos(int page, int pageSize);
        Task UpdatePhoto(Anthonia_Photoh photo);
        Task DeletePhoto(int id);
    }
}
