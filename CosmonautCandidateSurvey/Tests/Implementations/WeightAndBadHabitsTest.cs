using System.Linq;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Tests.Implementations
{
    public class WeightAndBadHabitsTest : ITest
    {
        public TestResultData Run(UserData userData)
        {
            var hasCold = userData.BadHabitsAndDiseases.Contains("Простуда");
            var hasVirus = userData.BadHabitsAndDiseases.Contains("Вирусы");
            var isSmoking = userData.BadHabitsAndDiseases.Contains("Курение");

            var testResult = new TestResultData();
            
            if ((hasCold || hasVirus) &&
                isSmoking &&
                userData.Weight is > 120 or < 60)
            {
                testResult.Result = TestResult.Unsatisfactory;
                testResult.ProblemMessages.Add("Кандидат курит, у кандидата простуда и/или вирусы, " +
                                               "и его вес больше 120 кг или меньше 60 кг");
                return testResult;
            }
            
            if ((hasCold || hasVirus) && userData.Weight > 110)
            {
                testResult.Result = TestResult.Satisfactory;
                testResult.ProblemMessages.Add("У кандидата есть простуда и/или вирусы, и его вес больше 110 кг");
                return testResult;
            }
         
            testResult.Result = TestResult.Good;
            return testResult;
        }
    }
}