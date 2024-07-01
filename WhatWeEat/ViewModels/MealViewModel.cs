using System.ComponentModel.DataAnnotations;

namespace WhatWeEat.ViewModels
{
    public class MealViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Name { get; set; }
    }
}