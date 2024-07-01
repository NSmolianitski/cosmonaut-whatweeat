using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class WeightAndBadHabitsTestTests
    {
        [TestCase(60, new [] {"Курение", "Простуда"})]
        [TestCase(70, new [] {"Курение", "Простуда"})]
        [TestCase(90, new [] {"Курение", "Простуда"})]
        [TestCase(110, new [] {"Курение", "Простуда"})]
        [TestCase(60, new [] {"Курение", "Вирусы"})]
        [TestCase(70, new [] {"Курение", "Вирусы"})]
        [TestCase(90, new [] {"Курение", "Вирусы"})]
        [TestCase(110, new [] {"Курение", "Вирусы"})]
        [TestCase(60, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(70, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(90, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(110, new [] {"Курение", "Простуда", "Вирусы"})]
        public void Run_WeightIsGood_ReturnGoodResultWithoutProblems(int weight, string[] badHabitsAndDiseases)
        {
            var userData = new UserData
            {
                Weight = weight,
                BadHabitsAndDiseases = badHabitsAndDiseases
            };

            var resultData = new WeightAndBadHabitsTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCase(111, new [] {"Курение", "Простуда"})]
        [TestCase(115, new [] {"Курение", "Простуда"})]
        [TestCase(119, new [] {"Курение", "Простуда"})]
        [TestCase(120, new [] {"Курение", "Простуда"})]
        [TestCase(111, new [] {"Курение", "Вирусы"})]
        [TestCase(115, new [] {"Курение", "Вирусы"})]
        [TestCase(119, new [] {"Курение", "Вирусы"})]
        [TestCase(120, new [] {"Курение", "Вирусы"})]
        [TestCase(111, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(115, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(119, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(120, new [] {"Курение", "Простуда", "Вирусы"})]
        public void Run_WeightIsSatisfactory_ReturnSatisfactoryResultWithProblemMessage(int weight, string[] badHabitsAndDiseases)
        {
            var userData = new UserData
            {
                Weight = weight,
                BadHabitsAndDiseases = badHabitsAndDiseases
            };

            var resultData = new WeightAndBadHabitsTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCase(121, new [] {"Курение", "Простуда"})]
        [TestCase(122, new [] {"Курение", "Простуда"})]
        [TestCase(140, new [] {"Курение", "Простуда"})]
        [TestCase(150, new [] {"Курение", "Простуда"})]
        [TestCase(59, new [] {"Курение", "Простуда"})]
        [TestCase(58, new [] {"Курение", "Простуда"})]
        [TestCase(50, new [] {"Курение", "Простуда"})]
        [TestCase(20, new [] {"Курение", "Простуда"})]
        [TestCase(121, new [] {"Курение", "Вирусы"})]
        [TestCase(122, new [] {"Курение", "Вирусы"})]
        [TestCase(140, new [] {"Курение", "Вирусы"})]
        [TestCase(150, new [] {"Курение", "Вирусы"})]
        [TestCase(59, new [] {"Курение", "Вирусы"})]
        [TestCase(58, new [] {"Курение", "Вирусы"})]
        [TestCase(50, new [] {"Курение", "Вирусы"})]
        [TestCase(20, new [] {"Курение", "Вирусы"})]
        [TestCase(121, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(122, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(140, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(150, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(59, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(58, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(50, new [] {"Курение", "Простуда", "Вирусы"})]
        [TestCase(20, new [] {"Курение", "Простуда", "Вирусы"})]
        public void Run_WeightIsUnsatisfactory_ReturnUnsatisfactoryResultWithProblemMessage(int weight, string[] badHabitsAndDiseases)
        {
            var userData = new UserData
            {
                Weight = weight,
                BadHabitsAndDiseases = badHabitsAndDiseases
            };

            var resultData = new WeightAndBadHabitsTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}