using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    /// <summary>
    /// Adapter class of US census data.
    /// </summary>
    public class USCensusAdapter : USCensusData, ICSVFileBuilder
    {
        public int StateLoadData(string filePath, string delimiter = ",", string header = null)
        {
            return 0;
        }
    }
}
