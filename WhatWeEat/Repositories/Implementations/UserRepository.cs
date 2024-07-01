using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatWeEat.Models;
using WhatWeEat.Repositories.Interfaces;

namespace WhatWeEat.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByNameAndEmailAsync(string name, string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Name == name && u.Email == email);
        }

        public async Task CreateUserAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}