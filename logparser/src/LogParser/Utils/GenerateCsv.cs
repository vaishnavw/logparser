using System;
using System.Collections.Generic;
using System.IO;

namespace LogParser
{
    public class GenerateCsv 
    {
        public void CreateCsvFile(List<LogParameters> logParameters, string csvFile)
        {

            string delimiter = ", ";
            string appendLogs;
            int counter = 1;

            if (!File.Exists(csvFile))
            {
                string createText = "No" + delimiter + "Level" + delimiter + "Date" + delimiter + "Time" 
                + delimiter+"Text" + Environment.NewLine;
                File.WriteAllText(csvFile, createText);
            }
            else
            {
                string line;
                int numberOfLines = 0;
               using (StreamReader sr = new StreamReader(csvFile))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            numberOfLines++;
                        }
                    } 
                    counter = numberOfLines;
            }

            foreach (LogParameters logParameter in logParameters)
            {
                appendLogs = counter++ + delimiter + logParameter.Level + delimiter + logParameter.Date + delimiter 
                + logParameter.Time + delimiter + logParameter.Description + delimiter + Environment.NewLine;
                File.AppendAllText(csvFile, appendLogs);
            }

        }
    }
}