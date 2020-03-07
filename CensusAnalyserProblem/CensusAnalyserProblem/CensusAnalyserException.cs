using System;
using System.IO;

namespace CensusAnalyserProblem
{
    public enum CensusException
    {
        Wrong_File_Path,
        Wrong_Delimiter
    }
    public class CensusAnalyserException : Exception
    {
       
        public string mgs;
        public CensusAnalyserException(string message)
        {
            this.mgs = message;
        }
    }
}
