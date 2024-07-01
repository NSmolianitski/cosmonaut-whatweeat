using System.Collections.Generic;
using System.Threading.Tasks;
using WhatWeEat.ViewModels;

namespace WhatWeEat.Services.Interfaces
{
    public interface IMealService
    {
        Task<List<MealViewModel>> GetAllMealsAsync();
        Task AddMealAsync(MealViewModel meal);
    }
}