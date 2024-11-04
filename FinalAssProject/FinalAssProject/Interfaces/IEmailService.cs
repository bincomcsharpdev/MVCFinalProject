using FinalAssProject.Models;

namespace FinalAssProject.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto contact);
    }
}
