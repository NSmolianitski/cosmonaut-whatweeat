using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhatWeEat.ViewModels
{
    public class FoodFormViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [MinLength(1)]
        [MaxLength(64, ErrorMessage = "Максимальная длина - 64 символа")] 
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }
        
        [Required] public string SelectedMeal { get; set; }
        public List<SelectListItem> Meals { get; set; }
    }
}