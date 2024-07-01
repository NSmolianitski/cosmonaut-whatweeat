using System.Threading.Tasks;
using WhatWeEat.Models;

namespace WhatWeEat.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByNameAndEmailAsync(string name, string email);
        Task CreateUserAsync(User user);
    }
}