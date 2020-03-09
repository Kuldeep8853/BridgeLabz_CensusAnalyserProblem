using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace CensusAnalyserProblem
{
    /// <summary>
    /// Declaring the delegates here return type and parameter type should 
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="delimiter"></param>
    /// <param name="header"></param>
    /// <returns></returns>
    public delegate int DelegateCsvStateDataLoad(string filePath, string delimiter = ",",  string header="");
    public class CSVState : ICSVFileBuilder
    {
        public int StateLoadData(string filePath, string delimiter = ",", string header = "StateCode")
        {
            try
            {
                var file_total = File.ReadLines(filePath);
                string[] line_element = file_total.ToArray();
                if (!line_element[0].Contains(header))
                {
                    throw new CensusAnalyserException(CensusException.Wrong_Header + "");
                }
                List<List<string>> StateData = new List<List<string>>();
                foreach (var line in File.ReadLines(filePath))
                {
                    List<string> list = new List<string>();
                    // process line here
                    string[] data = line.Split(delimiter);
                    if (data.Length < 2)
                    {
                        throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
                    }

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
