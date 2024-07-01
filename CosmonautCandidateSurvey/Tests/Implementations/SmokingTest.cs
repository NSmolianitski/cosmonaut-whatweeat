using System;
using System.Linq;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class SmokingTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var testResultData = new TestResultData();

            if (userData.BadHabitsAndDiseases.Contains("Курение", StringComparer.InvariantCultureIgnoreCase))
            {
                testResultData.Result = TestResult.Unsatisfactory;
                testResultData.ProblemMessages.Add("Кандидат курит");
                return testResultData;
            }
            
            testResultData.Result = TestResult.Good;
            return testResultData;
        }
    }
}