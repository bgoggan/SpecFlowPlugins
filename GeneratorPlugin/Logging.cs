using System;
using System.IO;

namespace GeneratorPlugin
{
    public static class Logging
    {
        private static Boolean logging = true;
        private static string path = @"C:\Dev\logs.txt";

        public static void WriteLine(string methodName, string message)
        {
            if (logging)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"[{methodName}]: {message}");
                }
            }
        }
    }
}
