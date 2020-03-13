// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserProblem
{
    using System;
    using System.IO;
    using System.Text;
    using ChoETL;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NPOI.SS.Formula.Functions;

    /// <summary>
    /// Utility class for using in CensusAnalyzerProblem.
    /// </summary>
    public class Utility
    {
        static int count;

        /// <summary>
        /// Method Convert Csv file to Json file.
        /// </summary>
        /// <param name="cSVFile">CSVFile.</param>
        /// <param name="jsonFile">JsonFile.</param>
        public static void ConvertCsvFileToJsonObject(string cSVFile, string jsonFile)
        {
            string re = File.ReadAllText(cSVFile);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re).WithFirstLineHeader())
            {
                using var w = new ChoJSONWriter(sb);
                w.Write(p);
            }

            File.WriteAllText(jsonFile, sb.ToString());
        }

        /// <summary>
        /// Method for sorting json File.
        /// </summary>
        /// <param name="path">path.</param>
        public static void SortStatePopulation(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if ((int)stateArrary[j]["DensityPerSqKm"] < (int)stateArrary[j + 1]["DensityPerSqKm"])
                    {
                        count++;
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }

            string jsonF = JsonConvert.SerializeObject(stateArrary, Formatting.Indented);
            File.WriteAllText(path, jsonF);
            Console.WriteLine(count);
        }

        /// <summary>
        /// Print the json file.
        /// </summary>
        /// <param name="path">path.</param>
        public static void PrintJsonFile(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count; i++)
            {
                Console.WriteLine(stateArrary[i]);
            }
        }

        /// <summary>
        /// Return The first element  state name of Json Array.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="elementName">elementName.</param>
        /// <returns>string.</returns>
        public static string FirstElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            return stateArrary[0][elementName].ToString();
        }

        /// <summary>
        /// Return The first element  state name of Json Array.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="elementName">elementName.</param>
        /// <returns>string.</returns>
        public static string LastElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            int length = stateArrary.Count;
            return stateArrary[length - 1][elementName].ToString();
        }
    }
}
