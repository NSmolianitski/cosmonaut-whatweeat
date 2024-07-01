using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class TherapistTestTests
    {
        [TestCase()]
        [TestCase("Насморк", "Ангина", "Алкоголизм")]
        [TestCase("Бронхит", "Курение")]
        [TestCase("Аллергия")]
        public void Run_GoodConditions_ReturnGoodResultWithoutProblems(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new TherapistTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCase("Алкоголизм", "Бессонница", "Травмы", "Курение", "Насморк", "Бронхит")]
        [TestCase("Бессонница", "Ангина", "Вирусы")]
        [TestCase("Наркомания", "Курение", "Аллергия", "Вирусы", "Ангина")]
        [TestCase("Травмы", "Наркомания", "Насморк", "Бронхит", "Аллергия")]
        public void Run_SatisfactoryConditions_ReturnSatisfactoryResultWithProblemMessage(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new TherapistTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCase("Алкоголизм", "Бессонница", "Наркомания", "Травмы", "Насморк", "Бронхит", "Аллергия", "Ангина", "Вирусы")]
        [TestCase("Насморк", "Бессонница", "Аллергия", "Ангина")]
        [TestCase("Наркомания", "Бронхит", "Вирусы", "Аллергия", "Ангина", "Травмы")]
        public void Run_UnsatisfactoryConditions_ReturnUnsatisfactoryResultWithProblemMessage(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new TherapistTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}