using Microsoft.AspNetCore.Identity.Data;
using ResumeMangerWebApi.DTO;

namespace ResumeMangerWebApi.Implementation.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterRequestDto request);
        Task<string> LoginAsync(LoginRequestDto request);
    }
}
