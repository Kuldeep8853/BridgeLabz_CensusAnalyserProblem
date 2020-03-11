// --------------------------------------------------------------------------------------------------------------------
// <copyright file=StateCensusAnalyser.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System.IO;
    using System.Linq;

    /// <summary>
    /// StateCensusAnalyzer class return file data.
    /// </summary>
    public class StateCensusAnalyser
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
            return data.Length;
        }
    }
}
