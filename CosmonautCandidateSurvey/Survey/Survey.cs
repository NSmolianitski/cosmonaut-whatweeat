using System;

namespace CosmonautCandidateSurvey.Survey
{
    public class Survey
    {
        public InputData GetInputData()
        {
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();
            
            Console.WriteLine("Введите вес (в килограммах):");
            var weight = Console.ReadLine();
            
            Console.WriteLine("Введите рост (в сантиметрах):");
            var height = Console.ReadLine();
            
            Console.WriteLine("Введите возраст:");
            var age = Console.ReadLine();
            
            Console.WriteLine("Введите остроту зрения:");
            var sight = Console.ReadLine();
            
            Console.WriteLine("Введите вредные привычки и болезни (разделяйте пробелом):");
            var badHabitsAndDiseases = Console.ReadLine();
            
            return new InputData
            {
                Name = name,
                Weight = weight,
                Height = height,
                Age = age,
                Sight = sight,
                BadHabitsAndDiseases = badHabitsAndDiseases
            };
        }
    }
}