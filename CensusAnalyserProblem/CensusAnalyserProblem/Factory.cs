// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Factory.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Factory class.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Return CSVStateCensus object.
        /// </summary>
        /// <returns>Value is.</returns>
        public ICSVFileBuilder GetObjectCSVStateCensus()
        {
            return new CSVStateCensus();
        }
    }
}
