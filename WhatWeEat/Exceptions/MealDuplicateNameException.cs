using System;
using System.Data;

namespace WhatWeEat.Exceptions
{
    public class MealDuplicateNameException : DuplicateNameException
    {
        public MealDuplicateNameException()
        {
        }

        public MealDuplicateNameException(string message)
            : base(message)
        {
        }

        public MealDuplicateNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}