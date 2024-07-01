using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class AgeTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();

            if (userData.Age > 37)
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Возраст больше 37");
                return testResultData;
            }
            
            if (userData.Age < 23)
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Возраст меньше 23");
                return testResultData;
            }

            if (userData.Age > 35)
            {
                testResultData.Result = TestResult.Satisfactory;
                testResultData.ProblemMessages.Add("Возраст больше 35");
                return testResultData;
            }

            if (userData.Age < 25)
            {
                testResultData.Result = TestResult.Satisfactory;
                testResultData.ProblemMessages.Add("Возраст меньше 25");
                return testResultData;
            }

            testResultData.Result = TestResult.Good;
            return testResultData;
        }
    }
}