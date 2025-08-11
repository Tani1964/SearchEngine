using System;
using System.IO;

namespace MyApp.Utils
{
    public static class Logger
    {
        private static string logFilePath = "logs.txt";

        public static void Log(string message)
        {
            var log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(log);
            File.AppendAllText(logFilePath, log + Environment.NewLine);
        }

        public static void LogError(Exception ex)
        {
            Log($"ERROR: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
