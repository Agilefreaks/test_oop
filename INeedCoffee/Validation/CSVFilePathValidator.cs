using System;
using System.IO;

namespace INeedCoffee
{
    public static class CSVFilePathValidator
    {
        public static bool Validate(string[] csvFileName)
        {
            string csvFilePath = FilePathCapture.Capture(csvFileName);

            if (File.Exists(csvFilePath) == false)
            {
                StandardMessages.DisplayValidationError(string.Format("CSV file!{0}The CSV File should be in the" +
                    " same location with the executable file.", Environment.NewLine));
                return false;
            }

            return true;
        }
    }
}
