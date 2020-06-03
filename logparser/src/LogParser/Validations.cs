using System;
using System.Collections.Generic;

namespace LogParser
{
    public class Validations
    {
        string message = "Please provide the correct Input arguments";
        public void ValidateInputArguments(string[] args)
        {
            if (args.Length % 2 == 1 || args.Length < 6)
            {
                ShowAppropriateUsage();
                throw new ApplicationException(message);
            }
        }

        public void ShowAppropriateUsage()
        {
            Console.WriteLine("\n Appropriate Arguments are:\n");
            Console.WriteLine("Usage: logParser --log-dir <dir> --log-level <level> --csv <out>");
            Console.WriteLine("\t --log-dir   Directory to parse recursively for .log files");
            Console.WriteLine("--csv       Out file-path (absolute/relative)");
        }

        public void ValidateLogLevels(List<string> logLevels)
        {
            int validCount = 0;
            LogLevels validLog = new LogLevels();
            string message = "Sorry! Log level you entered is not valid.";

            foreach(var level in logLevels){
               
                foreach(var validLevels in validLog.validLogLevel)
                {
                    if (validLevels.Equals(level)){
                        validCount++;
                    }
                }
            }

            if(validCount < logLevels.Count)
            {
               throw new Exception(message);
            }
            else
            {
                return;
            }
            
        }
    }
}