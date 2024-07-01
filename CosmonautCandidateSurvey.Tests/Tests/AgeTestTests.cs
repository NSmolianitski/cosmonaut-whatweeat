using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    namespace CosmonautCandidateSurvey.Tests
    {
        [TestFixture]
        public class AgeTestTests
        {
            private static readonly int[] UnsatisfactoryAgeValues = { 100, 51, 39, 38, 22, 21, 10, 5, 0 };
            private static readonly int[] SatisfactoryAgeValues = { 23, 24, 36, 37 };

            [Test]
            public void Run_AgeIsGood_ReturnGoodResultWithoutProblems([Range(25, 35)] int age)
            {
                var userData = new UserData
                {
                    Age = age
                };

                var resultData = new AgeTest().Run(userData);

                Assert.AreEqual(TestResult.Good, resultData.Result);
                Assert.IsEmpty(resultData.ProblemMessages);
            }

            [TestCaseSource(nameof(SatisfactoryAgeValues))]
            public void Run_AgeIsSatisfactory_ReturnSatisfactoryResultWithProblemMessage(int age)
            {
                var userData = new UserData
                {
                    Age = age
                };

                var resultData = new AgeTest().Run(userData);

                Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
                Assert.IsNotEmpty(resultData.ProblemMessages);
            }

            [TestCaseSource(nameof(UnsatisfactoryAgeValues))]
            public void Run_AgeIsUnsatisfactory_ReturnUnsatisfactoryResultWithProblemMessage(int age)
            {
                var userData = new UserData
                {
                    Age = age
                };

                var resultData = new AgeTest().Run(userData);

                Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
                Assert.IsNotEmpty(resultData.ProblemMessages);
            }
        }
    }
}