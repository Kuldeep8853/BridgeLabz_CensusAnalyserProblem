using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class Builder
    {
        public int Construct1(ICSVFileBuilder builder, string filePath, string delimiter = ",", string header = "")
        {
           int result= builder.StateLoadData(filePath, delimiter, header);
           return result;
        }
    }
}
