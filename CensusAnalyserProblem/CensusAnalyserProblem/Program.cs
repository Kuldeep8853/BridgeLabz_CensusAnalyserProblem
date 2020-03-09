using System;

namespace CensusAnalyserProblem
{
    class Program
    {
        public static void Main()
        {
            string Path1 = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            builder.Construct1(factory.GetObjectCSVStateCensus(), Path1,",", "AreaInSqKm");
            Console.WriteLine();
            string Path2 = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            builder.Construct1(factory.GetObjectCSVState(), Path2, ",", "StateCode");
        }
    }
}
 