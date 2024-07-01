using System.Linq;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class TherapistTest : ITest
    {
        private readonly string[] _diseases =
        {
            "Насморк",
            "Бронхит",
            "Вирусы",
            "Аллергия",
            "Ангина",
            "Бессонница"
        };
        
        public TestResultData Run(UserData userData)
        {
            var count = userData.BadHabitsAndDiseases
                .Count(badHabitOrDisease => _diseases.Contains(badHabitOrDisease));

            var testResult = new TestResultData();

            switch (count)
            {
                case > 3:
                    testResult.Result = TestResult.Unsatisfactory;
                    testResult.ProblemMessages.Add("Больше 3 болезней");
                    return testResult;
                case 3:
                    testResult.Result = TestResult.Satisfactory;
                    testResult.ProblemMessages.Add("2 болезни");
                    return testResult;
                default:
                    testResult.Result = TestResult.Good;
                    return testResult;
            }
        }
    }
}