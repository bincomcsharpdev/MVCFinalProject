using Microsoft.EntityFrameworkCore;
using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Anthonia_User> GetByUsernameAsync(string username)
        {
            return await _context.Anthonia_Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(Anthonia_User user)
        {
            _context.Anthonia_Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Anthonia_User> GetByIdAsync(int id)
        {
            return await _context.Anthonia_Users.FindAsync(id);
        }
    }
}
