using MVCFinalProject.Models;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Interfaces
{
    public interface IContactService
    {
        Task HandleContactMessageAsync(YahyContactMessage message);
    }
}
