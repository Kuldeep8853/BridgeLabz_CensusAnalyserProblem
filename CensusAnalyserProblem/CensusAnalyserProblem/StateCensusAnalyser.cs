using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class StateCensusAnalyser
    {
        public static int CSVLoadData(string filePath) 
        {
            var line = File.ReadLines(filePath);
            string[] data = line.ToArray();
            return data.Length;
        }
    }
}
