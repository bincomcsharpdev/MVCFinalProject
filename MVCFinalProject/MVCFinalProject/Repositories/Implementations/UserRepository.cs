using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Repositories.Interfaces;

namespace MVCFinalProject.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<YahyaUser> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<YahyaUser> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateAsync(YahyaUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

}