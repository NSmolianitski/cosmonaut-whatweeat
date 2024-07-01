using System.Collections.Generic;

namespace CosmonautCandidateSurvey.Tests
{
    public class TestResultData
    {
        public TestResult Result { get; set; }
        public List<string> ProblemMessages { get; } = new List<string>();
    }
}