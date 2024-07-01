using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatWeEat.Models;
using WhatWeEat.Repositories.Interfaces;

namespace WhatWeEat.Repositories.Implementations
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _db;
        
        public MealRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Meal>> GetAllMealsAsync()
        {
            return await _db.Meals.ToListAsync();
        }

        public Task<Meal> GetMealByNameAsync(string name)
        {
            return _db.Meals.FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task AddMealAsync(Meal meal)
        {
            _db.Meals.Add(meal);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsMealWithNameExists(string name)
        {
            return await _db.Meals.FirstOrDefaultAsync(m => m.Name == name) is not null;
        }
    }
}