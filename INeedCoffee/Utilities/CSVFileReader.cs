using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace INeedCoffee
{
    public static class CSVFileReader
    {
        public static List<string> Read(string[] csvFileNameFromTerminalArguments)
        {
            var csvFilePath = FilePathCapture.Capture(csvFileNameFromTerminalArguments);

            return File.ReadAllLines(csvFilePath).ToList();
        } 
    }
}
