using System;
using System.IO;
using static CensusAnalyserProblem.CensusAnalyserException;

namespace CensusAnalyserProblem
{
   public class CSVStateCensus
    {
        public static int CVSReadData(string filePath)
        {
            int Count = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                if (File.ReadLines(filePath) == null)
                {
                    throw new CensusAnalyserException(CensusException.Wrong_File_Path + "");
                }
                // process line here
                string[] data = line.Split(",");
                foreach (string a in data)
                {
                    Console.Write(a + "    ");
                }
                Console.WriteLine();
                Count++;
            }
            return Count;
        }

    }
}

