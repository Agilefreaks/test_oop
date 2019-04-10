using System.IO;

namespace INeedCoffee
{
    public static class FilePathCapture
    {
        public static string Capture(string[] csvFileNameFromTerminalArguments)
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), csvFileNameFromTerminalArguments[2]));
        }
    }
}
