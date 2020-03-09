using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public interface ICSVFileBuilder       
   {
        public int StateLoadData(string filePath, string delimiter = ",", string header = null);
    }
}
