using System;

namespace LogParser
{
    public class ProcessInputParameters
    {

        public InputParameters GetInputParameters(string[] args)
        {
            bool isLogDir = false;
            bool isCsvDir = false;

            const string logFile = InputParameters.inputDir;
            const string csvFile = InputParameters.ouputDir;
            const string loglevel = InputParameters.LogLevel;

            InputParameters inputParameters = new InputParameters();
            Validations validations = new Validations();

            for (int index = 0; index < args.Length; index++)
            {
                switch (args[index])
                {
                    case logFile:
                        if (!isLogDir)
                        {
                            inputParameters.logFilePath = args[++index];
                            isLogDir = true;
                        }
                        break;

                    case csvFile:
                        if (!isCsvDir)
                        {
                            inputParameters.csvFilePath = args[++index];
                            isCsvDir = true;
                        }
                        break;

                    case loglevel:
                        inputParameters.loglevel.Add(args[++index]);
                        break;

                    case "--help":
                    case "-h":
                        validations.ShowAppropriateUsage();
                        throw new Exception();
                        
                    default:
                        Console.WriteLine("Invalid input Paramters Passed");
                        break;
                }
            }

            return inputParameters;
        }
    } 
}