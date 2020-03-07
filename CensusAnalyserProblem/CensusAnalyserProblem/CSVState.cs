using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    // Declaring the delegates 
    // Here return type and parameter type should  
    // be same as the return type and parameter type 
    // of the two methods 
    // "CsvStateDataLoad" and "CheckDelimiter" are two delegate names 
    public delegate int DCsvStateDataLoad(string path);
    public delegate void DCheckCSVDelimiterAndHeader(string path, string header = "StateCode");
    public class CSVState
    {
        public static int StateLoadData(string filePath)
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
        public static void CheckDelimiterAndHeader(string filePath, string header = "StateCode")
        {
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            if (!line_element[0].Contains(header))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Header + "");
            }
            if (!file_total.Contains(";"))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
            }
        }
    }
}
