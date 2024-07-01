using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class WeightTestTests
    {
        private static readonly int[] UnsatisfactoryWeightValues = { 200, 120, 101, 69, 68, 65, 20 };
        private static readonly int[] SatisfactoryWeightValues = { 70, 71, 72, 73, 74, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

        [Test]
        public void Run_WeightIsGood_ReturnGoodResultWithoutProblems([Range(75, 90)] int weight)
        {
            var userData = new UserData
            {
                Weight = weight
            };

            var resultData = new WeightTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(SatisfactoryWeightValues))]
        public void Run_WeightIsSatisfactory_ReturnSatisfactoryResultWithProblemMessage(int weight)
        {
            var userData = new UserData
            {
                Weight = weight
            };

            var resultData = new WeightTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(UnsatisfactoryWeightValues))]
        public void Run_WeightIsUnsatisfactory_ReturnUnsatisfactoryResultWithProblemMessage(int weight)
        {
            var userData = new UserData
            {
                Weight = weight
            };

            var resultData = new WeightTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}