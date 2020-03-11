// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Factory.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;

    /// <summary>
    /// Enum Containing Type of Exception Message.
    /// </summary>
    public enum CensusException
    {
        /// <summary>
        /// Wrong File Path.
        /// </summary>
        Wrong_File_Path,

        /// <summary>
        /// Wrong Delimiter.
        /// </summary>
        Wrong_Delimiter,

        /// <summary>
        /// Wrong header.
        /// </summary>
        Wrong_Header,
    }

    /// <summary>
    /// Custom Exception class.
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// Instance variable of the CensusAnalyserException class.
        /// </summary>
        public string Mgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="message"> string type.</param>
        public CensusAnalyserException(string message)
        {
            this.Mgs = message;
        }
    }
}
