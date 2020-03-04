using System.IO;

namespace CensusAnalyserProblem
{
    public enum CensusException
    {
        Wrong_File_Path
    }
    public class CensusAnalyserException : FileNotFoundException
    {
       
        public string mgs;
        public CensusAnalyserException(string message)
        {
            this.mgs = message;
        }
    }
}
