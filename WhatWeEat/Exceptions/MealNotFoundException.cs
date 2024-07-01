using System;

namespace WhatWeEat.Exceptions
{
    public class MealNotFoundException : Exception
    {
        public MealNotFoundException()
        {
        }

        public MealNotFoundException(string message)
            : base(message)
        {
        }

        public MealNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}