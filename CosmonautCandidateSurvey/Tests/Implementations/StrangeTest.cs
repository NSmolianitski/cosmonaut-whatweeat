using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class StrangeTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var nameStartsWithP = userData.Name.StartsWith('П');
            
            var testResultData = new TestResultData();
            
            switch (nameStartsWithP)
            {
                case false when userData.Age <= 68:
                    testResultData.Result = TestResult.Unsatisfactory;
                    testResultData.ProblemMessages.Add("Имя кандидата не начинается с буквы 'П' и возраст меньше 69 лет");
                    return testResultData;
                case false:
                    testResultData.Result = TestResult.Satisfactory;
                    testResultData.ProblemMessages.Add("Имя кандидата не начинается с буквы 'П' и возраст больше 69 лет");
                    return testResultData;
                default:
                    testResultData.Result = TestResult.Good;
                    return testResultData;
            }
        }
    }
}