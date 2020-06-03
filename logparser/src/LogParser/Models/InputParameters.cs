using System.Collections.Generic;

namespace LogParser 
{
    public class InputParameters
    {
        public const string inputDir = "--log-dir";
        public const string ouputDir = "--csv";
        public const string LogLevel = "--log-level";

        public List<string> loglevel = new List<string>();
        public string logFilePath;
        public string csvFilePath;
        
    }
}