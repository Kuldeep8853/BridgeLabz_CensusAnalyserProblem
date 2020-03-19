// --------------------------------------------------------------------------------------------------------------------
// <copyright file=USCensusData.cs" Company="Bridgelabz">
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
    /// Load the us census data.
    /// </summary>
    public class USCensusData
    {
        /// <summary>
        /// Load data in Dictionary.
        /// </summary>
        /// <param name="filePath">filePath.</param>
        /// <returns>int.</returns>
        public static int LoadUsCensusData(string filePath)
        {
            int k = 1;
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            Dictionary<int, UsStateCensusDataDAO> map = new Dictionary<int, UsStateCensusDataDAO>();
            string[] key = line_element[0].Split(",");
            Utility.SortCSVFile(line_element);
            for (int i = 1; i < line_element.Length; i++)
            {
                UsStateCensusDataDAO node = new UsStateCensusDataDAO(line_element[i]);
                map.Add(k, node);
                k++;
            }

            foreach (var data in map)
            {
                Console.WriteLine("{");
                Console.WriteLine("StateId: " + data.Value.StateId);
                Console.WriteLine("State: " + data.Value.State);
                Console.WriteLine("Population: " + data.Value.Population);
                Console.WriteLine("Housing Units: " + data.Value.HousingUnits);
                Console.WriteLine("Total Area: " + data.Value.TotalArea);
                Console.WriteLine("Water Area: " + data.Value.WaterArea);
                Console.WriteLine("Land Area: " + data.Value.LandArea);
                Console.WriteLine("Population Density: " + data.Value.PopulationDensity);
                Console.WriteLine("Housing Density: " + data.Value.HousingDensity);
                Console.WriteLine("},");
            }

            return map.Count;
        }
    }
}
