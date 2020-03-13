// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SVStateCensus.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserProblem
{
    using System.IO;
    using System.Text;
    using ChoETL;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Utility class for using in CensusAnalyzerProblem.
    /// </summary>
    public class Utility
    {
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
        /// Sorting fuction for sort json file.
        /// </summary>
        /// <param name="path">path.</param>
        /// <returns>JArray.</returns>
        public static JArray SortCensus(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if (stateArrary[j]["State"].ToString().CompareTo(stateArrary[j + 1]["State"].ToString()) > 0)
                    {
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }

            return stateArrary;
        }

        /// <summary>
        /// Sorting fuction for sort json file.
        /// </summary>
        /// <param name="path">path.</param>
        /// <returns>JArray.</returns>
        public static JArray SortStateCode(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if (stateArrary[j]["StateCode"].ToString().CompareTo(stateArrary[j + 1]["StateCode"].ToString()) > 0)
                    {
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }

            return stateArrary;
        }
    }
}
