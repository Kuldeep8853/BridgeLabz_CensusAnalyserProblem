using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class Factory
    {
        public ICSVFileBuilder GetObjectCSVStateCensus()
        {
            return new CSVStateCensus();
        }

        public ICSVFileBuilder GetObjectCSVState()
        {
            return new CSVState();
        }
    }
}
