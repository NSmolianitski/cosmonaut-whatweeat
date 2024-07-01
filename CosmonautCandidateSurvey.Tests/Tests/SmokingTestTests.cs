using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class SmokingTestTests
    {
        [Test]
        public void Run_CandidateIsNotSmoking_ReturnGoodResultWithoutProblems()
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = new [] { "Насморк" }
            };

            var resultData = new SmokingTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [Test]
        public void Run_CandidateIsSmoking_ReturnUnsatisfactoryResultWithProblemMessage()
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = new [] { "Курение" }
            };

            var resultData = new SmokingTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}