using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class HeightTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();

            if (userData.Height < 160)
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Рост меньше 160");
                return testResultData;
            }
            
            if (userData.Height > 190)
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Рост больше 190");
                return testResultData;
            }
            
            if (userData.Height < 170)
            {
                testResultData.Result = TestResult.Satisfactory;
                testResultData.ProblemMessages.Add("Рост меньше 170");
                return testResultData;
            }
            
            if (userData.Height > 185)
            {
                testResultData.Result = TestResult.Satisfactory;
                testResultData.ProblemMessages.Add("Рост больше 185");
                return testResultData;
            }
            
            testResultData.Result = TestResult.Good;
            return testResultData;
        }
    }
}