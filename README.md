# logparser
C# Assignment 1: This code converts log files to Csv.

It is C# console application that converts a set of log files into a single CSV.
The program accepts input arguments from command line as below:

$ logParser.exe --log-dir <Dir-Path> --log-level <info|warn|debug>  
--log-level <info|warn|debug> --csv <Out-FilePath> 

1] --log-level can be passed multiple times to allow multiple log-levels to be filtered.
2] Parameters could be passed in any order

Working
1]Main method - LogParser: Main
2]Input Arguments are validated - Validations
3]Input Arguments are processed to InputParameter - Model
4]Inputparameters are validated
5]Read all log files and consider only valid logs (as per log Level)
6]All valid logs are converted to LogParamters - Model
    LogParameters fields are as per required format of Csv file
7]Csv File is generated - GenerateCsv
