using Microsoft.AspNetCore.Identity;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<YahyaUser> FindByEmailAsync(string email);
        Task<YahyaUser> GetUserByIdAsync(Guid userId);
        Task UpdateAsync(YahyaUser user);
    }

}
