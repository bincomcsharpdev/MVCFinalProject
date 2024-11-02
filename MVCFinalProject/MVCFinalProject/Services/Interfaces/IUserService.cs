using Microsoft.AspNetCore.Identity;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<YahyaUser> FindByEmailAsync(string email);
        Task<YahyaUser> GetUserAsync(Guid userId);
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto registrationDto);
        Task UpdateUserAsync(Guid userId, UserUpdateDto updateDto);
    }


}
