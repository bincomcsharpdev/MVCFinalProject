using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Implementations
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(YahyContactMessage message)
        {
            await _context.YahyContactMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<YahyContactMessage>> GetAllMessagesAsync()
        {
            return await _context.YahyContactMessages.ToListAsync();
        }
    }
}
