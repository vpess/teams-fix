using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeamsFix
{
    class Logger
    {
        private static readonly string FileName = "teams_fix.log";
        private static readonly string FilePath = $"{Path.localAppData}";
        private static readonly string LogFile = $@"{FilePath}\{FileName}";

        public static void InsertInfo(string info)
        {
            string dateTime = DateTime.Now.ToString();
            string logString = $"{dateTime}: {info}\n";

            File.AppendAllText(LogFile, logString);
        }
    }
}
