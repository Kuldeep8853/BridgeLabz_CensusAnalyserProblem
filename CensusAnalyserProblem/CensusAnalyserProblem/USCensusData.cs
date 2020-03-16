// --------------------------------------------------------------------------------------------------------------------
// <copyright file=USCensusData.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------

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
        public static void LoadUsCensusData(string filePath)
        {
            int k = 1;
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = line_element[0].Split(",");
            Utility.SortCSVFile(line_element);
            for (int i = 1; i < line_element.Length; i++)
            {
                string[] value = line_element[i].Split(",");
                Dictionary<string, string> subMap = new Dictionary<string, string>()
               {
                   { key[0], value[0] },
                   { key[1], value[1] },
                   { key[2], value[2] },
                   { key[3], value[3] },
                   { key[4], value[4] },
                   { key[5], value[5] },
                   { key[6], value[6] },
               };

                map.Add(k, subMap);
                k++;
            }

            foreach (var data in map)
            {
                Console.WriteLine("{");
                foreach (var data1 in data.Value)
                {
                    Console.WriteLine(" " + data1);
                }

                Console.WriteLine("},");
            }

            Console.WriteLine(map.Count);
        }
    }
}
