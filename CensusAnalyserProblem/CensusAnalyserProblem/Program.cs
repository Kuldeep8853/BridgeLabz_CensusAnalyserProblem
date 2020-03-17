// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Factory.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ---------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

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
            // Utility.SortStatePopulation(@"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVState.json");
            //var file_total = File.ReadLines(@"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv");
            //Dictionary<int, StateCodeDataDAO> map = new Dictionary<int, StateCodeDataDAO>();
            //string[] line_element = file_total.ToArray();
            //for (int i = 1; i < line_element.Length; i++)
            //{
            //    StateCodeDataDAO node = StateCodeDataDAO.CreateNode(line_element[i]);
            //    map.Add(i, node);
            //}

            //foreach (KeyValuePair<int, StateCodeDataDAO> data in map)
            //{
            //    Console.WriteLine(data.Value.ToString());
            //}
            Utility.MergeStateCensusAndStateCode();
        }
    }
}
