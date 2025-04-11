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

        public string Format(string originalLog)
        {
            Regex format1Date = new(@"(?<!\S)([0-3][0-9]\.[0-1][0-9]\.[0-9]{4})(?!\S)");
            Regex format2Date = new(@"(?<!\S)([0-9]{4}-[0-1][0-9]-[0-3][0-9](?!\S))");
           
            StringBuilder resultLog = new(originalLog);

            // string originalDateFormat = format1Date.Match(originalLog).ToString();
            string originalDateFormat = format1Date.IsMatch(originalLog) ?
                format1Date.Match(originalLog).ToString() :
                format2Date.Match(originalLog).ToString();
            var rusCulture = CultureInfo.GetCultureInfo("ru-RU");
            if (DateOnly.TryParse(originalDateFormat, rusCulture, out DateOnly date))
            {
                resultLog.Replace(originalDateFormat + " ", date.ToString("dd-MM-yyyy\t", CultureInfo.InvariantCulture));
            }
            string callingMethod = "DEFAULT\t";


            if (originalLog.Contains('|'))
            {
                resultLog = resultLog.Replace("| ", "|");

                Regex infoRegex = new(@"INFO\|(.*?)\|");
                Regex warnRegex = new(@"WARN\|(.*?)\|");
                Regex errorRegex = new(@"ERROR\|(.*?)\|");
                Regex debugRegex = new(@"DEBUG\|(.*?)\|");

                string? info = infoRegex.Match(originalLog).ToString();
                string? warning = warnRegex.Match(originalLog).ToString();
                string? error = errorRegex.Match(originalLog).ToString();
                string? debug = debugRegex.Match(originalLog).ToString();

                if (infoRegex.IsMatch(originalLog))
                    resultLog= resultLog.Replace(info, "INFO|");

                if (warnRegex.IsMatch(originalLog))
                    resultLog = resultLog.Replace(warning, "WARN|");

                if (errorRegex.IsMatch(originalLog))
                    resultLog = resultLog.Replace(error, "ERROR|");

                if (debugRegex.IsMatch(originalLog))
                    resultLog = resultLog.Replace(debug, "DEBUG|");

                resultLog = resultLog.Replace("|", "\t");

                 return resultLog.ToString();
            }
            else
            {

                resultLog.Replace(" INFORMATION ", $"\tINFO\t{callingMethod}")
                    .Replace(" WARNING ", $"\tWARN\t{callingMethod}")
                    .Replace(" ERROR ", $"\tERROR\t{callingMethod}")
                    .Replace(" DEBUG ", $"\tDEBUG\t{callingMethod}");
            }
                return resultLog.ToString();
        }
    }
}
