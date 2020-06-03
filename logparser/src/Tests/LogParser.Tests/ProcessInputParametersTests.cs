using System;
using Xunit;

namespace LogParser.Tests
{
    public class ProcessInputParametersTests
    {
        [Fact]
        public void EnsureArgumentsProcessedToInputParameters()
        {
            ProcessInputParameters processInputParameters = new ProcessInputParameters();
            string[] args = "--log-dir ..'\'LogFiles'\' --log-level info --csv ..'\'CsvFiles'\'csv1.csv";
            
            var expected = new InputParametersTests(){
                logLevel = new List<string>() {"info"},
                csvFilePath = "..'\'LogFiles'\'",
                logFilePath = "..'\'CsvFiles'\'csv1.csv"
            };

            var result = processInputParameters.GetInputParameters(args);

            Assert.True(result.Equals(expected));
        }
    }
}