// --------------------------------------------------------------------------------------------------------------------
// <copyright file=CSVState.cs" Company="Bridgelabz">
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
    /// CSVState class.
    /// </summary>
    public class CSVState : ICSVFileBuilder
    {
        /// <summary>
        /// StateLoadData method.
        /// </summary>
        /// <param name="filePath">filePath.</param>
        /// <param name="delimiter">delimiter.</param>
        /// <param name="header">header.</param>
        /// <returns>Integer.</returns>
        public int StateLoadData(string filePath, string delimiter = ",", string header = "StateCode")
        {
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            if (!line_element[0].Contains(header))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Header + string.Empty);
            }

            int k = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = line_element[0].Split(delimiter);
            if (key.Length < 2)
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + string.Empty);
            }

            for (int i = 1; i < line_element.Length; i++)
            {
               string[] value = line_element[i].Split(",");
               Dictionary<string, string> subMap = new Dictionary<string, string>()
               {
                   { key[0], value[0] },
                   { key[1], value[1] },
                   { key[2], value[2] },
                   { key[3], value[3] },
               };

               map.Add(k, subMap);
               k++;
            }

            foreach (var data in map)
            {
                Console.WriteLine("{");
                foreach (var data1 in data.Value)
                {
                    Console.WriteLine(data1);
                }

                Console.WriteLine("},");
            }

            return map.Count;
        }
    }
}
