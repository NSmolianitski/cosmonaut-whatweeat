using CosmonautCandidateSurvey.Survey;
using CosmonautCandidateSurvey.Tests.Implementations;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Tests
{
    [TestFixture]
    public class PsychologistTestTests
    {
        [TestCase(new object[] {})]
        [TestCase(new object[] {"Насморк", "Ангина", "Вирусы"})]
        [TestCase(new object[] {"Бронхит", "Курение"})]
        [TestCase(new object[] {"Аллергия"})]
        public void Run_GoodConditions_ReturnGoodResultWithoutProblems(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new PsychologistTest().Run(userData);

            Assert.AreEqual(TestResult.Good, resultData.Result);
            Assert.IsEmpty(resultData.ProblemMessages);
        }

        [TestCase(new object[] {"Алкоголизм"})]
        [TestCase(new object[] {"Бессонница", "Ангина", "Вирусы"})]
        [TestCase(new object[] {"Наркомания", "Курение"})]
        [TestCase(new object[] {"Травмы"})]
        public void Run_SatisfactoryConditions_ReturnSatisfactoryResultWithProblemMessage(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new PsychologistTest().Run(userData);

            Assert.AreEqual(TestResult.Satisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }

        [TestCase(new object[] {"Алкоголизм", "Бессонница", "Наркомания", "Травмы"})]
        [TestCase(new object[] {"Алкоголизм", "Бессонница"})]
        [TestCase(new object[] {"Наркомания", "Травмы"})]
        public void Run_UnsatisfactoryConditions_ReturnUnsatisfactoryResultWithProblemMessage(params string[] diseases)
        {
            var userData = new UserData
            {
                BadHabitsAndDiseases = diseases
            };

            var resultData = new PsychologistTest().Run(userData);

            Assert.AreEqual(TestResult.Unsatisfactory, resultData.Result);
            Assert.IsNotEmpty(resultData.ProblemMessages);
        }
    }
}