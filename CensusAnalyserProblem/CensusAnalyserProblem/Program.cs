// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Factory.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;

    /// <summary>
    /// This is main class of CensusAnalyserProblem Project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of CensusAnalyserProblem Project.
        /// </summary>
        public static void Main()
        {
            // string jsonPath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVStateCensus.json";
            // Utility.SortStatePopulation(jsonPath);
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            cSVStateCensus.StateLoadData(@"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv");
        }
    }
}
