using System.Collections.Generic;
using System.Threading.Tasks;
using WhatWeEat.Models;

namespace WhatWeEat.Repositories.Interfaces
{
    public interface IEatRecordRepository
    {
        Task<List<EatRecord>> GetMostRecentEatRecordsAsync(int count);
        Task CreateEatRecordAsync(EatRecord eatRecord);
        Task<int> CountTodayEatRecordsForMealAsync(long mealId);
        Task<int> CountAllEatRecordsForMealByUserAsync(long mealId, long userId);
    }
}