using System.Collections.Generic;
using System.Threading.Tasks;
using WhatWeEat.ViewModels;

namespace WhatWeEat.Services.Interfaces
{
    public interface IEatRecordService
    {
        Task<List<string>> GetMostRecentEatRecordViewsAsync();
        Task<string> CreateNewEatRecordAndReturnWelcomeMessageAsync(EatRecordViewModel eatRecordViewModel);
    }
}