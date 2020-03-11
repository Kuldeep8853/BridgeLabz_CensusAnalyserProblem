//// ----------------------------------------------------------------------------------------------------------------------
//// <copyright file=Builder.cs" Company="Bridgelabz">
//// Copyright © 2020 Company="BridgeLabz"
//// </copyright>
//// <creator name="Kuldeep Kasaudhan"/>
//// ----------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserProblem
{
    using System.IO;

    /// <summary>
    /// Creating delegate and call the Builder method.
    /// </summary>
    /// <param name = "builder"> builder. </param>
    /// <param name = "filePath"> file Path. </param>
    /// <param name = "delimiter"> delimiter. </param>
    /// <param name = "header"> header. </param>
    /// <returns> Hello hi. </returns>
    public delegate string DelegateCsvStateDataLoad(ICSVFileBuilder builder, string filePath, string delimiter = ",", string header = "");

    /// <summary>
    /// Builder class use like Director of Project.
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// This is Construct of the builder class.
        /// </summary>
        /// <param name="builder"> builder. </param>
        /// <param name="filePath">filePath.</param>
        /// <param name="delimiter">delimiter.</param>
        /// <param name="header">header.</param>
        /// <returns>result.</returns>
        public static string Construct(ICSVFileBuilder builder, string filePath, string delimiter = ",", string header = "")
        {
            try
            {
                int result = builder.StateLoadData(filePath, delimiter, header);
                return result.ToString();
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + string.Empty);
            }
        }
    }
}
