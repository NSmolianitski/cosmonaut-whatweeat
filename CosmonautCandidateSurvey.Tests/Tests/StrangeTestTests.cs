using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class StrangeTestTests
    {
        private static readonly string[] GoodNameValues = { "Пётр Иванов", "Павел", "Порфирий", "Потап" };
        private static readonly string[] NotGoodNameValues = { "Алексей Иванов", "Иван", "Александр", "Михаил" };
        private static readonly int[] SatisfactoryAgeValues = { 69, 70, 75, 100, 123 };
        private static readonly int[] UnsatisfactoryAgeValues = { 68, 67, 45, 20, 10 };
        
        [TestCaseSource(nameof(GoodNameValues))]
        public void Run_GoodConditions_ReturnGoodResultWithoutProblems(string name)
        {
            var userData = new UserData
            {
                Name = name,
                Age = 20
            };

            var resultData = new StrangeTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [Test]
        public void Run_SatisfactoryConditions_ReturnSatisfactoryResultWithProblemMessage(
            [ValueSource(nameof(NotGoodNameValues))] string name, 
            [ValueSource(nameof(SatisfactoryAgeValues))] int age)
        {
            var userData = new UserData
            {
                Name = name,
                Age = age
            };

            var resultData = new StrangeTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [Test]
        public void Run_UnsatisfactoryConditions_ReturnUnsatisfactoryResultWithProblemMessage(
            [ValueSource(nameof(NotGoodNameValues))] string name, 
            [ValueSource(nameof(UnsatisfactoryAgeValues))] int age)
        {
            var userData = new UserData
            {
                Name = name,
                Age = age
            };
            
            var resultData = new StrangeTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}