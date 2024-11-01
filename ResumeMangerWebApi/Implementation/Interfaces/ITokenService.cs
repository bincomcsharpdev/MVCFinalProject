using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Implementation.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Anthonia_User user);
    }
}
