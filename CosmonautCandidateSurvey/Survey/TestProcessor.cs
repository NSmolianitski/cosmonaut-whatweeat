using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmonautCandidateSurvey.Tests;
using CosmonautCandidateSurvey.Tests.Implementations;
using CosmonautCandidateSurvey.Tests.Interfaces;

namespace CosmonautCandidateSurvey.Survey
{
    public class TestProcessor
    {
        private readonly List<ITest> _tests = new List<ITest>
        {
            new WeightTest(),
            new HeightTest(),
            new AgeTest(),
            new SightTest(),
            new SmokingTest(),
            new TherapistTest(),
            new PsychologistTest(),
            new WeightAndBadHabitsTest(),
            new StrangeTest(),
            new MathematicalTest()
        };

        public string RunTests(UserData userData)
        {
            var testResults = _tests.Select(t => t.Run(userData)).ToList();
            var surveyPassed = CheckCandidatePassing(testResults);
            
            var problems = testResults
                .SelectMany(r => r.ProblemMessages
                    .Select(p => $"{p} ({TestResultToString(r.Result)})"));
            
            return GetSurveyResultMessage(surveyPassed, userData.Name, problems);
        }

        private bool CheckCandidatePassing(IEnumerable<TestResultData> results)
        {
            var satisfactoryResultsCount = 0;
            foreach (var result in results)
            {
                if (result.Result is TestResult.Unsatisfactory)
                    return false;

                if (result.Result is TestResult.Satisfactory)
                {
                    ++satisfactoryResultsCount;
                    if (satisfactoryResultsCount > 3)
                        return false;
                }
            }
            
            return true;
        }
        
        private string GetSurveyResultMessage(bool testPassed, string userName, IEnumerable<string> problems)
        {
            if (testPassed)
                return $"Кандидат {userName} подходит";

            var stringBuilder = new StringBuilder();
            foreach (var problem in problems)
                stringBuilder.Append($"* {problem}\n");
            
            return $"Кандидат {userName} не прошел тестирование. Проблемы:\n{stringBuilder}";
        }
        
        private string TestResultToString(TestResult testResult)
        {
            return testResult switch
            {
                TestResult.Satisfactory => "удовлетворительно",
                TestResult.Unsatisfactory => "неудовлетворительно",
                _ => "хорошо"
            };
        }
    }
}