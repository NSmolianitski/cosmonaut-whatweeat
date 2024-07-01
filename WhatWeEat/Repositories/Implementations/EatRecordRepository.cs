using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatWeEat.Models;
using WhatWeEat.Repositories.Interfaces;

namespace WhatWeEat.Repositories.Implementations
{
    public class EatRecordRepository : IEatRecordRepository
    {
        private readonly ApplicationDbContext _db;

        public EatRecordRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<EatRecord>> GetMostRecentEatRecordsAsync(int count)
        {
            return await _db.EatRecords
                .Include(r => r.Meal)
                .Include(r => r.User)
                .OrderByDescending(r => r.Timestamp)
                .Take(count)
                .ToListAsync();
        }

        public async Task CreateEatRecordAsync(EatRecord eatRecord)
        {
            _db.EatRecords.Add(eatRecord);
            await _db.SaveChangesAsync();
        }

        public Task<int> CountTodayEatRecordsForMealAsync(long mealId)
        {
            return _db.EatRecords
                .Where(r => r.Timestamp.Date == DateTime.Today && r.Meal.Id == mealId)
                .CountAsync();
        }

        public Task<int> CountAllEatRecordsForMealByUserAsync(long mealId, long userId)
        {
            return _db.EatRecords
                .Where(r => r.Meal.Id == mealId && r.User.Id == userId)
                .CountAsync();
        }
    }
}