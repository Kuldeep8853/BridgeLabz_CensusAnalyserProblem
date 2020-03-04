using System;

namespace CensusAnalyserProblem
{
    class Program
    {
        public static void Main()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            int record=StateCensusAnalyser.StateLoadData(Path);
            Console.WriteLine(record);
            int LineOfData= CSVStateCensus.CVSReadData(Path);
            Console.WriteLine(LineOfData);
        }
    }
}
