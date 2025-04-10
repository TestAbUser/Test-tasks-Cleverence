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
            var logArr = log.Split(" ");
            Regex dateRegex = new("([0-3][0-9]\\.[0-1][0-9]\\.[0-9]{4})");
            StringBuilder newLog = new(log);//new string[log.Length];
                                            //foreach (var item in log)
                                            //{
                                            // Regex regexInfoLoggingLevel = new("INFORMATION");
                                            //string warningLoggingLevel = "WARNING";
            string originalDateFormat = dateRegex.Match(log).ToString();
            var rusCulture = CultureInfo.GetCultureInfo("ru-RU");
            if (DateOnly.TryParse(originalDateFormat, rusCulture, out DateOnly date))
            {
                newLog.Replace(originalDateFormat + " ", date.ToString("o", CultureInfo.InvariantCulture) + "\t");
            }
            string callingMethod = "DEFAULT\t";

            string logLevel = Regex.IsMatch(log, "INFORMATION") ?
                $"\tINFO\t{callingMethod}" : Regex.IsMatch(log, "WARNING") ?
                $"\tWARN\t{callingMethod}" : Regex.IsMatch(log, "ERROR") ?
                $"\tERROR\t{callingMethod}" : Regex.IsMatch(log, "DEBUG") ?
                $"\tDEBUG\t{callingMethod}" : "";


            if (!log.Contains('|'))
            {
                newLog.Replace(" INFORMATION ", logLevel)
                    .Replace(" WARNING ", $"\tWARN\t{callingMethod}")
                    .Replace(" ERROR ", $"\tERROR\t{callingMethod}")
                    .Replace(" DEBUG ", $"\tDEBUG\t{callingMethod}");
            }

            //log

            //newLog = newLog.Replace(" ", "\t");
            // newLog = newLog.Replace("WARNING","WARN");
            // }
            return newLog.ToString();
        }
    }
}
