using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Implementation.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
