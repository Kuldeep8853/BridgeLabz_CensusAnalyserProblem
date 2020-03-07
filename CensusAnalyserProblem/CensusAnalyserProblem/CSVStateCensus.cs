using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyserProblem
{
   public class CSVStateCensus
    {
        public static int CVSReadData(string filePath)
        {
            try
            {
                List<List<string>> StateData = new List<List<string>>();
                foreach (var line in File.ReadLines(filePath))
                {
                    List<string> list = new List<string>();
                    // process line here
                    string[] data = line.Split(",");
                    foreach (string subData in data)
                    {
                        list.Add(subData);
                    }
                    StateData.Add(list);

                }
                List<List<string>>.Enumerator iterator = StateData.GetEnumerator();
                while (iterator.MoveNext())
                {
                    List<string> line = iterator.Current;
                    foreach (string data in line)
                    {
                        Console.Write(data + " ");
                    }
                    Console.WriteLine();
                }
                return StateData.Count;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + "");
            }
        }
    }
}

