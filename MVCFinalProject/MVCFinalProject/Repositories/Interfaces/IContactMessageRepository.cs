using MVCFinalProject.Models;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject
{
    public interface IContactMessageRepository
    {
        Task AddMessageAsync(YahyContactMessage message);
        Task<IEnumerable<YahyContactMessage>> GetAllMessagesAsync();
        //Task SaveChangesAsync();

    }
}
