// --------------------------------------------------------------------------------------------------------------------
// <copyright file=StateCensusAnalyser.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// StateCensusAnalyzer class return file data.
    /// </summary>
    public class StateCensusAnalyser : IAdapter
    {
        /// <summary>
        /// CSVLoadData method return file.
        /// </summary>
        /// <param name = "filePath"> filePath. </param>
        /// <returns>data Length.</returns>
        public static int CSVLoadData(string filePath)
        {
            var line = File.ReadLines(filePath);
            string[] data = line.ToArray();
            return data.Length - 1;
        }

        /// <summary>
        /// Return The first element  state name of Json Array.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="elementName">elementName.</param>
        /// <returns>string.</returns>
        public string FirstElementNameOfJsonArray(string path, string elementName)
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
        public string LastElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            int length = stateArrary.Count;
            return stateArrary[length - 1][elementName].ToString();
        }
    }
}
