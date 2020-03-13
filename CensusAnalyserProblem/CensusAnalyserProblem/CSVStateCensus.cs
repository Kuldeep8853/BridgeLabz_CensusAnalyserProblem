﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SVStateCensus.cs" Company="Bridgelabz">
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
    using System.Text;
    using ChoETL;

    /// <summary>
    /// CSVStateCensus class Read and Load CSV File.
    /// </summary>
    public class CSVStateCensus : ICSVFileBuilder
    {
        /// <summary>
        /// StateLoadData method.
        /// </summary>
        /// <param name="filePath">filePath.</param>
        /// <param name="delimiter">delimiter.</param>
        /// <param name="header">header.</param>
        /// <returns>Integer.</returns>
        public int StateLoadData(string filePath, string delimiter = ",", string header = "AreaInSqKm")
        {
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            if (!line_element[0].Contains(header))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Header + string.Empty);
            }

            List<List<string>> stateData = new List<List<string>>();
            foreach (var line in File.ReadLines(filePath))
            {
                List<string> list = new List<string>();

                // process line here
                string[] data = line.Split(delimiter);
                if (data.Length < 2)
                {
                    throw new CensusAnalyserException(CensusException.Wrong_Delimiter + string.Empty);
                }

                foreach (string subData in data)
                {
                    list.Add(subData);
                }

                stateData.Add(list);
            }

            List<List<string>>.Enumerator iterator = stateData.GetEnumerator();
            while (iterator.MoveNext())
            {
                List<string> line = iterator.Current;
                foreach (string data in line)
                {
                    Console.Write(data + " ");
                }

                Console.WriteLine();
            }

            return stateData.Count;
        }
    }
}
