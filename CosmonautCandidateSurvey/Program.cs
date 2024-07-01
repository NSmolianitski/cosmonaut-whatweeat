using System;
using CosmonautCandidateSurvey.Survey;

namespace CosmonautCandidateSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            var userSurveyProvider = new Survey.Survey();
            var inputParser = new InputParser();
            var testProcessor = new TestProcessor();
            bool repeatTesting;

            do
            {
                var inputData = userSurveyProvider.GetInputData();
                var parsingResult = inputParser.Parse(inputData);

                if (parsingResult.Errors.Count is 0)
                {
                    var result = testProcessor.RunTests(parsingResult.UserData);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("\nПри обработке данных возникли ошибки:");
                    foreach (var error in parsingResult.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }

                repeatTesting = AskToRepeatSurvey();
                Console.WriteLine();

            } while (repeatTesting);
            
            Console.WriteLine("Спасибо за участие в опросе!");
        }

        private static bool AskToRepeatSurvey()
        {
            Console.WriteLine("\nХотите протестировать других кандидатов? (Y/N)");
            while (true)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine("\nНажмите Y или N.");
                        break;
                }
            }
        }
    }
}