// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Factory.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;

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
            string cSVFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            string jsonFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVState.json";
            Utility.ConvertCsvFileToJsonObject(cSVFilePath, jsonFilePath);
            JArray stateArray=Utility.SortStateCode(jsonFilePath);
            string json = JsonConvert.SerializeObject(stateArray, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
