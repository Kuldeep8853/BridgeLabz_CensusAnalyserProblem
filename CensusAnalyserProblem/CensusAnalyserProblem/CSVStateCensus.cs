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

    public class CSVStateCensus : ICSVFileBuilder
    {
        /// <inheritdoc/>
        public int StateLoadData(string filePath, string delimiter = ",", string header = "AreaInSqKm")
        {
            try
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + string.Empty);
            }
        }
    }
}
