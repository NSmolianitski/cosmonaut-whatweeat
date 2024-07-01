using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatWeEat.Exceptions;
using WhatWeEat.Models;
using WhatWeEat.Repositories.Interfaces;
using WhatWeEat.Services.Interfaces;
using WhatWeEat.ViewModels;

namespace WhatWeEat.Services.Implementations
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<List<MealViewModel>> GetAllMealsAsync()
        {
            var meals = await _mealRepository.GetAllMealsAsync();
            return meals.Select(m => new MealViewModel { Name = m.Name }).ToList();
        }

        public async Task AddMealAsync(MealViewModel mealViewModel)
        {
            if (await _mealRepository.IsMealWithNameExists(mealViewModel.Name))
            {
                throw new MealDuplicateNameException(mealViewModel.Name);
            }
                
            var meal = new Meal { Name = mealViewModel.Name };
            await _mealRepository.AddMealAsync(meal);
        }
    }
}