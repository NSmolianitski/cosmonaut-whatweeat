using System.Collections.Generic;

namespace CosmonautCandidateSurvey.Survey
{
    public class ParsingResult
    {
        public List<string> Errors { get; } = new List<string>();
        public UserData UserData { get; set; }
    }
}