using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class HeightTestTests
    {
        private static readonly int[] UnsatisfactoryHeightValues = { 200, 195, 191, 159, 158, 150, 10 };
        private static readonly int[] SatisfactoryHeightValues = { 160, 163, 165, 169, 186, 187, 188, 189, 190 };

        [Test]
        public void Run_HeightIsGood_ReturnGoodResultWithoutProblems([Range(170, 185)] int height)
        {
            var userData = new UserData
            {
                Height = height
            };

            var resultData = new HeightTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(SatisfactoryHeightValues))]
        public void Run_HeightIsSatisfactory_ReturnSatisfactoryResultWithProblemMessage(int height)
        {
            var userData = new UserData
            {
                Height = height
            };

            var resultData = new HeightTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(UnsatisfactoryHeightValues))]
        public void Run_HeightIsUnsatisfactory_ReturnUnsatisfactoryResultWithProblemMessage(int height)
        {
            var userData = new UserData
            {
                Height = height
            };

            var resultData = new HeightTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}