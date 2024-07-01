using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WhatWeEat.Exceptions;
using WhatWeEat.Models;
using WhatWeEat.Repositories.Interfaces;
using WhatWeEat.Services.Interfaces;
using WhatWeEat.ViewModels;

namespace WhatWeEat.Services.Implementations
{
    public class EatRecordService : IEatRecordService
    {
        private readonly IEatRecordRepository _eatRecordRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IUserRepository _userRepository;
        private readonly int _mostRecentEatRecordsCount;

        public EatRecordService(
            IEatRecordRepository eatRecordRepository,
            IMealRepository mealRepository,
            IUserRepository userRepository,
            IConfiguration configuration
        )
        {
            _eatRecordRepository = eatRecordRepository;
            _mealRepository = mealRepository;
            _userRepository = userRepository;
            _mostRecentEatRecordsCount = int.Parse(configuration["AppSettings:MostRecentEatRecordsCount"]);
        }

        public async Task<List<string>> GetMostRecentEatRecordViewsAsync()
        {
            var eatRecords = await _eatRecordRepository
                .GetMostRecentEatRecordsAsync(_mostRecentEatRecordsCount);
            
            return eatRecords.Select(r => 
                $"{r.Timestamp:HH:mm:ss dd/MM/yyyy} {r.User.Name} ({r.User.Email}) съел {r.Meal.Name}")
                .ToList();
        }

        public async Task<string> CreateNewEatRecordAndReturnWelcomeMessageAsync(EatRecordViewModel eatRecordViewModel)
        {
            var meal = await _mealRepository.GetMealByNameAsync(eatRecordViewModel.MealName);
            if (meal is null)
                throw new MealNotFoundException(eatRecordViewModel.MealName);

            var user = await _userRepository.GetUserByNameAndEmailAsync(eatRecordViewModel.UserName,eatRecordViewModel.UserEmail);

            var isNewUser = user is null;
            if (isNewUser)
            {
                user = new User
                {
                    Name = eatRecordViewModel.UserName,
                    Email = eatRecordViewModel.UserEmail
                };
                await _userRepository.CreateUserAsync(user);
            }
            
            var eatRecord = new EatRecord {Meal = meal, Timestamp = DateTime.Now, User = user};
            await _eatRecordRepository.CreateEatRecordAsync(eatRecord);

            return await GetWelcomeMessageAsync(user, meal, isNewUser);
        }

        private async Task<string> GetWelcomeMessageAsync(User user, Meal meal, bool isNewUser)
        {
            var allTodayMealEatRecords = await _eatRecordRepository.CountTodayEatRecordsForMealAsync(meal.Id);
            string welcomeMessage;
            if (isNewUser)
            {
                welcomeMessage = $"{user.Name}, мы рады приветствовать вас в нашем сообществе! " +
                                 $"Вы только что съели {meal.Name}! " +
                                 $"За сегодня {meal.Name} было съедено {allTodayMealEatRecords} раз!";
            }
            else
            {
                var allMealEatRecordsForUser = await _eatRecordRepository
                    .CountAllEatRecordsForMealByUserAsync(meal.Id, user.Id);
                welcomeMessage = $"{user.Name}, с возвращением! " +
                                 $"Вы только что съели {meal.Name}! " +
                                 $"Всего вы съели {meal.Name} {allMealEatRecordsForUser} раз! " +
                                 $"За сегодня {meal.Name} было съедено {allTodayMealEatRecords} раз!";
            }
            
            return welcomeMessage;
        }
    }
}
