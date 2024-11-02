using Microsoft.AspNetCore.Identity;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Repositories.Interfaces;
using MVCFinalProject.Services.Interfaces;

namespace MVCFinalProject.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<YahyaUser> _userManager;
        private readonly IPasswordHasher<YahyaUser> _passwordHasher;

        public UserService(IUserRepository userRepository, UserManager<YahyaUser> userManager, IPasswordHasher<YahyaUser> passwordHasher)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> ValidateUserAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.FindByEmailAsync(loginDto.Email);
            if (user == null) return false;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<YahyaUser> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<YahyaUser> GetUserAsync(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto registrationDto)
        {
            var user = new YahyaUser
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                UserName = registrationDto.Email,
                DateOfBirth = registrationDto.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            return result;
        }

        public async Task UpdateUserAsync(Guid userId, UserUpdateDto updateDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found.");

            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.Email = updateDto.Email;
            user.DateOfBirth = updateDto.DateOfBirth;

            await _userRepository.UpdateAsync(user);
        }
    }

}
