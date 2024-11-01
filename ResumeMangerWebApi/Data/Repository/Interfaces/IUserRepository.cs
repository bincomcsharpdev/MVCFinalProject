using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Anthonia_User> GetByUsernameAsync(string username);
        Task AddUserAsync(Anthonia_User user);
        Task<Anthonia_User> GetByIdAsync(int id);
    }
}
