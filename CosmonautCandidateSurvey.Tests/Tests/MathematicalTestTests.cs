using System;
using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class MathematicalTestTests
    {
        private static readonly int[] UnsatisfactoryHeightValues = { 3, 6, 9, 150, 180, 162 };
        private static readonly int[] SatisfactoryHeightValues = { 3, 9, 151, 181, 163 };
        private static readonly int[] GoodHeightValues = { 2, 6, 4, 150, 180, 162 };

        [TestCaseSource(nameof(GoodHeightValues))]
        public void Run_GoodConditions_ReturnGoodResultWithoutProblems(int height)
        {
            var userData = new UserData
            {
                Height = height,
                BadHabitsAndDiseases = Array.Empty<string>()
            };

            var resultData = new MathematicalTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(SatisfactoryHeightValues))]
        public void Run_SatisfactoryConditions_ReturnSatisfactoryResultWithProblemMessage(int height)
        {
            var userData = new UserData
            {
                Height = height,
                BadHabitsAndDiseases = new [] { "Курение" }
            };

            var resultData = new MathematicalTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCaseSource(nameof(UnsatisfactoryHeightValues))]
        public void Run_UnsatisfactoryConditions_ReturnUnsatisfactoryResultWithProblemMessage(int height)
        {
            var userData = new UserData
            {
                Height = height,
                BadHabitsAndDiseases = new [] { "Насморк" }
            };

            var resultData = new MathematicalTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}