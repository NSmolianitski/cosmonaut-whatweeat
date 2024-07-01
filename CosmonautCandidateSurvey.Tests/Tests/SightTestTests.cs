using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class SightTestTests
    {
        private static readonly float[] UnsatisfactorySightValues = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f };

        [TestCase(1)]
        public void Run_SightIsGood_ReturnGoodResultWithoutProblems(float sight)
        {
            var userData = new UserData
            {
                Sight = sight
            };

            var resultData = new SightTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(UnsatisfactorySightValues))]
        public void Run_SightIsUnsatisfactory_ReturnUnsatisfactoryResultWithProblemMessage(float sight)
        {
            var userData = new UserData
            {
                Sight = sight
            };

            var resultData = new SightTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}