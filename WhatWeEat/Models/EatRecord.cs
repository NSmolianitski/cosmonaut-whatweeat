using System;

namespace WhatWeEat.Models
{
    public class EatRecord
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public long MealId { get; set; }
        public Meal Meal { get; set; } = null!;
    }
}