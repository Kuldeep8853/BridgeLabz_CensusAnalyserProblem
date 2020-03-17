// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" Company="Bridgelabz">
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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Utility class for using in CensusAnalyzerProblem.
    /// </summary>
    public class Utility
    {
        private static int count;

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
                w.Close();
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
                    if (stateArrary[j]["StateName"].ToString().CompareTo(stateArrary[j + 1]["StateName"].ToString()) > 0)
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

        /// <summary>
        /// Sort the csv file.
        /// </summary>
        /// <param name="lines">filePath.</param>
        public static void SortCSVFile(string[] lines)
        {
            for (int i = 0; i < lines.Length - 1; i++)
            {
                for (int j = 1; j < lines.Length - i - 1; j++)
                {
                    if (lines[j - 1].CompareTo(lines[j + 1]) > 0)
                    {
                        string tamp = lines[j];
                        lines[j] = lines[j + 1];
                        lines[j + 1] = tamp;
                    }
                }
            }
        }

        /// <summary>
        /// Merge the state cde data and state census data.
        /// </summary>
        public static void MergeStateCensusAndStateCode()
        {
            var file_total = File.ReadLines(@"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv");
            var file_total1 = File.ReadLines(@"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv");
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
            string[] line_element = file_total.ToArray();
            string[] line_element1 = file_total1.ToArray();
            for (int i = 1; i < line_element1.Length; i++)
            {
                List<string> list = new List<string>();
                StateCodeDataDAO node = StateCodeDataDAO.CreateNode(line_element[i]);
                StateCensusDataDAO node1 = StateCensusDataDAO.CreateNode(line_element1[i]);
                list.Add(node.serialNo.ToString());
                list.Add(node.stateCode);
                list.Add(node.stateName);
                list.Add(node.tIN.ToString());
                list.Add(node1.population.ToString());
                list.Add(node1.areaInSqKm.ToString());
                list.Add(node1.densityPerSqKm.ToString());
                map.Add(i, list);
            }

            foreach (var data in map)
            {
                Console.WriteLine("{ ");
                Console.WriteLine("SerialNo: " + data.Value[0]);
                Console.WriteLine("StateCode: " + data.Value[1]);
                Console.WriteLine("StateName: " + data.Value[2]);
                Console.WriteLine("TIN: " + data.Value[3]);
                Console.WriteLine("Population: " + data.Value[4]);
                Console.WriteLine("AreaInSqKm: " + data.Value[5]);
                Console.WriteLine("DensityPerSqKm: " + data.Value[6]);
                Console.WriteLine(" },");
            }
        }
    }
}
