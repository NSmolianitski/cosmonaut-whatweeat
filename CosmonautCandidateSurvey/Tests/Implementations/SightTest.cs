using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class SightTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();

            if (userData.Sight < 1)
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Зрение меньше 1");
                return testResultData;
            }

            testResultData.Result = TestResult.Good;
            return testResultData;
        }
    }
}