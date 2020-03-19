// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    /// <summary>
    /// Interface IAdapter.
    /// </summary>
    public interface IAdapter
    {
        /// <summary>
        /// Delare FirstElementNameOfJsonArra method and return type is string.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="elementName">elementName.</param>
        /// <returns>string.</returns>
        public string FirstElementNameOfJsonArray(string path, string elementName);

        /// <summary>
        /// Delare LastElementNameOfJsonArray method and return type is string.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="elementName">elementName.</param>
        /// <returns>string.</returns>
        public string LastElementNameOfJsonArray(string path, string elementName);
    }
}
