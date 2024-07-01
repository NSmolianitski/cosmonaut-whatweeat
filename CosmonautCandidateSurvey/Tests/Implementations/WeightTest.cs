using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class WeightTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();

            switch (userData.Weight)
            {
                case > 100:
                    testResultData.Result = TestResult.Unsatisfactory;
                    testResultData.ProblemMessages.Add("Вес больше 100");
                    return testResultData;
                case < 70:
                    testResultData.Result = TestResult.Unsatisfactory;
                    testResultData.ProblemMessages.Add("Вес меньше 70");
                    return testResultData;
                case > 90:
                    testResultData.Result = TestResult.Satisfactory;
                    testResultData.ProblemMessages.Add("Вес больше 90");
                    return testResultData;
                case < 75:
                    testResultData.Result = TestResult.Satisfactory;
                    testResultData.ProblemMessages.Add("Вес меньше 75");
                    return testResultData;
                default:
                    testResultData.Result = TestResult.Good;
                    return testResultData;
            }
        }
    }
}