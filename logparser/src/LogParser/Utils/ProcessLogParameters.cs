using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogParser
{
    public class ProcessLogParameters
    {
        const string firstWord  = @"(?<=^(\S+\s){0})\S+";
        const string secondWord = @"(?<=^(\S+\s){1})\S+";
        const string thirdWord = @"(?<=^(\S+\s){2})\S+";
        public List<LogParameters> GenerateLogParamters(List<string> activeLogs)
        {
            List<LogParameters> logParameters=new List<LogParameters>();

            foreach (var log in activeLogs)
             {
                LogParameters logParameter = PopulateFields(log);

                logParameters.Add(logParameter);
            }

            return logParameters;
        }

        public LogParameters PopulateFields(string line){
            
            var logParameter = new LogParameters();

            // line = line.Replace(",", "\",\"");
		    line = line.Replace("   ", " ");

            string[] fields = line.Split(":.");

            var dateField = Regex.Match(fields[0], firstWord).ToString();
            DateTime dt = DateTime.Parse(dateField);
            logParameter.Date = ($"{dt.Day} {dt.ToString("MMMM")} {dt.Year}").ToString();

            var timeField = Regex.Match(fields[0], secondWord).ToString();
            DateTime tm = DateTime.Parse(timeField);
            logParameter.Time = tm.ToShortTimeString();

            logParameter.Level = Regex.Match(fields[0], thirdWord).ToString();

            logParameter.Description = ":." + fields[1].Trim();

            return logParameter;
        }
    }
}