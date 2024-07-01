using System.Linq;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class PsychologistTest : ITest
    {
        private readonly string[] _diseases =
        {
            "Алкоголизм",
            "Бессонница",
            "Наркомания",
            "Травмы"
        };
        
        public TestResultData Run(UserData userData)
        {
            var count = userData.BadHabitsAndDiseases
                .Count(badHabitOrDisease => _diseases.Contains(badHabitOrDisease));

            var testResult = new TestResultData();

            switch (count)
            {
                case > 1:
                    testResult.Result = TestResult.Unsatisfactory;
                    testResult.ProblemMessages.Add("Больше 1 болезни");
                    return testResult;
                case 1:
                    testResult.Result = TestResult.Satisfactory;
                    testResult.ProblemMessages.Add("1 болезнь");
                    return testResult;
                default:
                    testResult.Result = TestResult.Good;
                    return testResult;
            }
        }
    }
}