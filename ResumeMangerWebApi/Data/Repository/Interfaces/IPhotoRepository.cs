using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task UploadPhoto(Anthonia_Photo photo);
        Task<Anthonia_Photo> GetPhotoById(int id);
        Task<IEnumerable<Anthonia_Photo>> GetPhotos(int page, int pageSize);
        Task UpdatePhoto(Anthonia_Photo photo);
        Task DeletePhoto(int id);
    }
}
