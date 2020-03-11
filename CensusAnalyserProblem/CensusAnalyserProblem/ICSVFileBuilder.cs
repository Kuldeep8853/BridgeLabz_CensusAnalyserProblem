//// ----------------------------------------------------------------------------------------------------------------------
//// <copyright file=ICSVFileBuilder.cs" Company="Bridgelabz">
//// Copyright © 2020 Company="BridgeLabz"
//// </copyright>
//// <creator name="Kuldeep Kasaudhan"/>
//// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ICSVFileBuilder is Interface.
    /// </summary>
    public interface ICSVFileBuilder
    {
        /// <summary>
        /// StateLoadData is a Abtract Method.
        /// </summary>
        /// <param name="filePath">filePath.</param>
        /// <param name="delimiter">delimiter.</param>
        /// <param name="header">header.</param>
        /// <returns>This is Integer.</returns>
        public int StateLoadData(string filePath, string delimiter = ",", string header = null);
    }
}
