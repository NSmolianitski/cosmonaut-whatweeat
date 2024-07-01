using CosmonautCandidateSurvey.Survey;
using NUnit.Framework;

namespace CosmonautCandidateSurvey.Tests.Survey
{
    [TestFixture]
    public class TestProcessorTests
    {
        [Test]
        public void RunTests_UserDataIsGood_PrintSuccessMessage()
        {
            var testProcessor = new TestProcessor();
            var userData = new UserData
            {
                Name = "Пётр",
                Age = 25,
                Height = 170,
                Weight = 75,
                Sight = 1,
                BadHabitsAndDiseases = new[] {"Травмы"}
            };
            const string expectedResult = "Кандидат Пётр подходит";
            
            var actualResult = testProcessor.RunTests(userData);
            
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void RunTests_UserDataIsBad_PrintSuccessMessage()
        {
            var testProcessor = new TestProcessor();
            var userData = new UserData
            {
                Name = "Андрей",
                Age = 80,
                Height = 170,
                Weight = 75,
                Sight = 1,
                BadHabitsAndDiseases = new[] {"Травмы"}
            };
            const string expectedResult = "Кандидат Андрей не прошел тестирование. Проблемы:\n" +
                                          "* Возраст больше 37 (неудовлетворительно)\n" +
                                          "* 1 болезнь (удовлетворительно)\n" +
                                          "* Имя кандидата не начинается с буквы 'П' и возраст больше 69 лет (удовлетворительно)\n";
            
            var actualResult = testProcessor.RunTests(userData);
            
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}