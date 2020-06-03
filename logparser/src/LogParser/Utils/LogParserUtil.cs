using System;
using System.Collections.Generic;
using System.IO;

namespace LogParser
{
    public class LogParserUtil
    {
        public List<string> ReadLogFiles(InputParameters inputParameters)
        {
            string logFileDir = inputParameters.logFilePath;
            string[] files = GetLogFiles(logFileDir);
            
            List<string> logs = new List<string>();
            string line;

            Console.WriteLine("***LogParser: Log files converting to Csv***");
            Console.WriteLine("Log files converted to Csv is/are:");

            foreach (var file in files)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Length > 10)
                                logs.Add(line);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could not read file/files from --log-dir", logFileDir);
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(file);
            }

            List<string> activeLogs = GetRequiredLogs(logs, inputParameters.loglevel);
            
            return activeLogs;

        }

        public List<string> GetRequiredLogs(List<string> logs, List<string> logLevel){
            List<string> activeLogs=new List<string>();

            foreach(var log in logs){
                foreach(var level in logLevel){
                    if(log.Contains(level.ToUpper()))
                    activeLogs.Add(log);
                }
            }
            return activeLogs;
        }

        public string[] GetLogFiles(string logFileDir){

            string[] files= new string[] {};
            try
            {
                files = Directory.GetFiles(logFileDir, "*.log");
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not read file/files from --log-dir", logFileDir);
                Console.WriteLine(e.Message);
            }

            return files;
        }
    }
}