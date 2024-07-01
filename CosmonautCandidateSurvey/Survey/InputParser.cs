using System.Globalization;

namespace CosmonautCandidateSurvey.Survey
{
    public class InputParser
    {
        public ParsingResult Parse(InputData inputData)
        {
            var parsingResult = new ParsingResult();
            if (!int.TryParse(inputData.Age, out var age))
                parsingResult.Errors.Add($"Возраст должен быть целым числом. Получено: {inputData.Age}");
            
            if (!int.TryParse(inputData.Height, out var height))
                parsingResult.Errors.Add($"Рост должен быть целым числом. Получено: {inputData.Height}");
            
            if (!int.TryParse(inputData.Weight, out var weight))
                parsingResult.Errors.Add($"Вес должен быть целым числом. Получено: {inputData.Weight}");
            
            if (!float.TryParse(inputData.Sight, NumberStyles.Any, CultureInfo.InvariantCulture, out var sight))
                parsingResult.Errors.Add($"Зрение должно быть дробным числом. Получено: {inputData.Sight}");
            
            parsingResult.UserData = new UserData
            {
                Name = inputData.Name,
                Age = age,
                Height = height,
                Weight = weight,
                Sight = sight,
                BadHabitsAndDiseases = inputData.BadHabitsAndDiseases.Split(' ')
            };
            
            AddDataValidationErrors(parsingResult);
            
            return parsingResult;
        }
        
        private void AddDataValidationErrors(ParsingResult parsingResult)
        {
            var userData = parsingResult.UserData;
            var errors = parsingResult.Errors;
            
            if (string.IsNullOrWhiteSpace(userData.Name))
                errors.Add("Имя не может быть пустым");
            
            if (userData.Age < 0)
                errors.Add($"Возраст должен быть больше нуля. Получено: {userData.Age}");
            
            if (userData.Height < 0)
                errors.Add($"Рост должен быть больше нуля. Получено: {userData.Height}");
            
            if (userData.Weight < 0)
                errors.Add($"Вес должен быть больше нуля. Получено: {userData.Weight}");
            
            if (userData.Sight is < 0 or > 1)
                errors.Add($"Зрение должно быть в диапазоне от 0 до 1. Получено: {userData.Sight}");
        }
    }
}