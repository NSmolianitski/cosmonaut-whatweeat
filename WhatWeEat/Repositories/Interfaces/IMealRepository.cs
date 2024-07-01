using System.Collections.Generic;
using System.Threading.Tasks;
using WhatWeEat.Models;

namespace WhatWeEat.Repositories.Interfaces
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetAllMealsAsync();
        Task<Meal> GetMealByNameAsync(string name);
        Task AddMealAsync(Meal meal);
        Task<bool> IsMealWithNameExists(string name);
    }
}