using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogFileStandardization
{
    public class LogFormatter
    {

        public string Format(string log)
        {
           var logArr= log.Split(" ");
             Regex dateRegex = new("([0-3][0-9]\\.[0-1][0-9]\\.[0-9]{4})");
            string newLog = "";//new string[log.Length];
                               //foreach (var item in log)
                               //{
                               // Regex regexInfoLoggingLevel = new("INFORMATION");
                               //string warningLoggingLevel = "WARNING";
            string originalDateFormat =dateRegex.Match(log).ToString();
            var rusCulture= CultureInfo.GetCultureInfo("ru-RU");
                if(DateOnly.TryParse(originalDateFormat, rusCulture, out DateOnly date))
                {
                    newLog = log.Replace(originalDateFormat, date.ToString("o", CultureInfo.InvariantCulture));
                }

            newLog = newLog.Replace("INFORMATION","INFO");
            newLog = newLog.Replace(" ", "\t");
            // newLog = newLog.Replace("WARNING","WARN");
            // }
            return newLog;
        }
    }
}
