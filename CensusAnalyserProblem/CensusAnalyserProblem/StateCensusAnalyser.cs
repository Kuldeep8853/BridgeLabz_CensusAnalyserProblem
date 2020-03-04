using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace CensusAnalyserProblem
{
    public class StateCensusAnalyser
    {
        public static int StateLoadData(string filePath)
        {
            try
            {
                int count = 0;
                using TextFieldParser parser = new TextFieldParser(filePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                        Console.Write(field + "    ");
                    }
                    Console.WriteLine();
                    count++;
                }
                return count;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + "");
            }
            
        }

    }
}
