using System;

namespace CensusAnalyserProblem
{
    class Program
    {
        public static void Main()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            CSVState.StateLoadData(Path);
        }
    }
}
