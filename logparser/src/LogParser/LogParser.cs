using System;
using System.Collections.Generic;

namespace LogParser
{
    public class LogParser
    {
        
        public static void Main(string[] args)
        {
            InputParameters inputParameters = new InputParameters();
            LogParserUtil logParserUtil = new LogParserUtil();
            ProcessLogParameters processLogParameters = new ProcessLogParameters();
            GenerateCsv generateCsv = new GenerateCsv();
            ProcessInputParameters processInputParameters = new ProcessInputParameters();
            Validations validations = new Validations();




            
            validations.ValidateInputArguments(args);

            inputParameters = processInputParameters.GetInputParameters(args);

            validations.ValidateLogLevels(inputParameters.loglevel);

            List<string> activeLogs = logParserUtil.ReadLogFiles(inputParameters);

            var logParameters = processLogParameters.GenerateLogParamters(activeLogs);

            generateCsv.CreateCsvFile(logParameters, inputParameters.csvFilePath);
        }
    }
}
