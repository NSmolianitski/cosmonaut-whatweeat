using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhatWeEat.Exceptions;
using WhatWeEat.Services.Interfaces;
using WhatWeEat.ViewModels;

namespace WhatWeEat.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IMealService _mealService;
        private readonly IEatRecordService _eatRecordService;

        public HomeController(
            IMealService mealService,
            IEatRecordService eatRecordService
        )
        {
            _mealService = mealService;
            _eatRecordService = eatRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new FoodFormViewModel
            {
                Meals = await GetMealsSelectListAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitForm(FoodFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Meals = await GetMealsSelectListAsync();
                return View(nameof(Index), viewModel);
            }

            var eatRecordViewModel = new EatRecordViewModel
            {
                UserName = viewModel.UserName,
                UserEmail = viewModel.Email,
                MealName = viewModel.SelectedMeal
            };

            var allEatRecordViews = await _eatRecordService.GetMostRecentEatRecordViewsAsync();
            var welcomeMessage = await _eatRecordService
                .CreateNewEatRecordAndReturnWelcomeMessageAsync(eatRecordViewModel);

            var feedViewModel = new FeedViewModel
            {
                WelcomeMessage = welcomeMessage,
                EatRecords = allEatRecordViews
            };

            return RedirectToAction(nameof(Feed), feedViewModel);
        }


        [HttpGet]
        [Route("/feed")]
        public IActionResult Feed(FeedViewModel feedViewModel)
        {
            return View(feedViewModel);
        }

        private async Task<List<SelectListItem>> GetMealsSelectListAsync()
        {
            var meals = await _mealService.GetAllMealsAsync();

            return meals.Select(
                    m => new SelectListItem
                    {
                        Value = m.Name,
                        Text = m.Name
                    })
                .ToList();
        }

        [HttpPost]
        [Route("/meals")]
        public async Task<IActionResult> CreateMeal(MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mealService.AddMealAsync(mealViewModel);
                    return Json(new {success = true});
                }
                catch (MealDuplicateNameException)
                {
                    ModelState.AddModelError(
                        nameof(mealViewModel.Name),
                        "Это блюдо уже кто-то когда-то ел"
                    );
                }
            }

            var errors = ModelState
                .Where(kvp => kvp.Value.Errors.Count > 0)
                .Select(kvp => new
                {
                    kvp.Key,
                    kvp.Value.Errors.First().ErrorMessage
                });

            return Json(new
            {
                success = false,
                errors
            });
        }
    }
}