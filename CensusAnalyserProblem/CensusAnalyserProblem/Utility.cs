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
        /// Merge the both file data in Indian census data.
        /// </summary>
        /// <returns> Dictionary.<int, Dictionary<string, string>>.</returns>
        public static Dictionary<int, Dictionary<string, string>> IndianCensusData()
        {
            string[] censusData = File.ReadAllLines(@"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv");
            string[] stateCodeData = File.ReadAllLines(@"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv");
            Dictionary<int, Dictionary<string, string>> indiaData = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> keyValuePairs = null;
            string[] censusHead = censusData[0].Split(',');
            string[] stateCodeHead = stateCodeData[0].Split(',');
            for (int i = 1; i < stateCodeData.Length; i++)
            {
                keyValuePairs = new Dictionary<string, string>();
                string[] data1 = stateCodeData[i].Split(',');
                for (int j = 1; j < censusData.Length; j++)
                {
                    string[] data2 = censusData[j].Split(',');
                    if (data1[1].ToString().Equals(data2[0].ToString()))
                    {
                        int a = 1;
                        for (int k = 0; k < data2.Length; k++)
                        {
                            keyValuePairs.Add(stateCodeHead[k], data1[k]);
                            if (a < 4)
                            {
                                keyValuePairs.Add(censusHead[a], data2[a]);
                                a++;
                            }
                        }

                        break;
                    }
                }

                for (int k = 0; k < data1.Length; k++)
                {
                    try
                    {
                        keyValuePairs.Add(stateCodeHead[k], data1[k]);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                indiaData.Add(i, keyValuePairs);
            }

            string indiajsonPath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\IndianCensusData.json";
            var json = JsonConvert.SerializeObject(indiaData, Formatting.Indented);
            File.WriteAllText(indiajsonPath, json);
            string jsonObj = File.ReadAllText(indiajsonPath);
            var jsonArray = JsonConvert.DeserializeObject(jsonObj);
            Console.WriteLine(jsonArray);
            return indiaData;
        }
    }
}
