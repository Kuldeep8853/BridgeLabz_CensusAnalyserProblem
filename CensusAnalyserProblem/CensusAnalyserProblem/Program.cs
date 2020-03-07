using System;

namespace CensusAnalyserProblem
{
    class Program
    {
        public static void Main()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVState.StateLoadData);
            DCheckCSVDelimiterAndHeader del1 = new DCheckCSVDelimiterAndHeader(CSVState.CheckDelimiterAndHeader);
            Console.WriteLine(del(Path));
           del1(Path);
        }
    }
}
