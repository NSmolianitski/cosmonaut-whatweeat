using System.Collections;
using System.Collections.Generic;
using CosmonautCandidateSurvey.Survey;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CosmonautCandidateSurvey.Tests.Survey
{
    [TestFixture]
    public class InputParserTests
    {
        [Test]
        public void Parse_WrongInputDataTypes_ReturnErrors()
        {
            var inputData = new InputData
            {
                Name = "name",
                Age = "Age",
                Height = "Height",
                Weight = "Weight",
                Sight = "Sight",
                BadHabitsAndDiseases = "badHabitsAndDiseases"
            };
            const int expectedErrorsCount = 4;
            
            var parsingResult = new InputParser().Parse(inputData);
            
            Assert.AreEqual(expectedErrorsCount, parsingResult.Errors.Count);
        }
        
        [Test]
        public void Parse_ValidationErrors_ReturnErrors(
            [Values("", null)] string name,
            [Values(-10, -5, -1)] int age,
            [Values(-10, -5, -1)] int height,
            [Values(-10, -5, -1)] int weight,
            [Values(-1f, -0.5f, -0.1f, 1.1f, 2f)] float sight)
        {
            var inputData = new InputData
            {
                Name = $"{name}",
                Age = $"{age}",
                Height = $"{height}",
                Weight = $"{weight}",
                Sight = $"{sight}",
                BadHabitsAndDiseases = "badHabitsAndDiseases"
            };
            const int expectedErrorsCount = 5;
            
            var parsingResult = new InputParser().Parse(inputData);
            
            Assert.AreEqual(expectedErrorsCount, parsingResult.Errors.Count);
        }
    }
}