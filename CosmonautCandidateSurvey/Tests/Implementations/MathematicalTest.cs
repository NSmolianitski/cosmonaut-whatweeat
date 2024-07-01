using System.Linq;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class MathematicalTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();
            
            if (userData.Height % 3 is 0 &&
                userData.BadHabitsAndDiseases.Contains("Насморк"))
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Рост делится нацело на 3, и у кандидата насморк");
                return testResultData;
            }

            if (userData.Height % 2 is not 0)
            {
                testResultData.Result = TestResult.Satisfactory;
                testResultData.ProblemMessages.Add("Рост не делится нацело на 2");
                return testResultData;
            }

            testResultData.Result = TestResult.Good;
            return testResultData;
        }
    }
}