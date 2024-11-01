using Microsoft.AspNetCore.Identity.Data;
using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.DTO;
using ResumeMangerWebApi.Entities;
using ResumeMangerWebApi.Implementation.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ResumeMangerWebApi.Implementation.Services
{
    public class UserService(IUserRepository userRepository, ITokenService tokenService) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<bool> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
            if (existingUser != null)
                return false;

            var user = new User
            {
                Username = request.Username,
                PasswordHash = HashPassword(request.Password)
            };

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<string> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null || user.PasswordHash != HashPassword(request.Password))
                return null;

            return _tokenService.GenerateToken(user);
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }

}
