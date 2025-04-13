using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LogFileStandardization
{
    public class LogFormatter
    {

        public string[] Format(string[]? originalLog)
        {
            ArgumentNullException.ThrowIfNull(originalLog, nameof(originalLog));

            Regex format1Date = new(@"(?<!\S)([0-3][0-9]\.[0-1][0-9]\.[0-9]{4})(?!\S)");
            Regex format2Date = new(@"(?<!\\S)([0-9]{4}-[0-1][0-9]-[0-3][0-9])(?!\\S)");

            StringBuilder resultLog = new();
            foreach (var line in originalLog)
            {
                StringBuilder resultLogLine = new(line);

                string originalDateFormat = format1Date.IsMatch(line) ?
                    format1Date.Match(line).ToString() :
                    format2Date.Match(line).ToString();

                var rusCulture = CultureInfo.GetCultureInfo("ru-RU");

                if (DateOnly.TryParse(originalDateFormat, rusCulture, out DateOnly date))
                {
                    resultLogLine.Replace(originalDateFormat + " ", date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "\t");
                }
                const string callingMethod = "DEFAULT\t";

                if (line.Contains('|'))
                {
                    resultLogLine = resultLogLine.Replace("| ", "|");

                    Regex infoRegex = new(@"INFO\|(.*?)\|");
                    Regex warnRegex = new(@"WARN\|(.*?)\|");
                    Regex errorRegex = new(@"ERROR\|(.*?)\|");
                    Regex debugRegex = new(@"DEBUG\|(.*?)\|");

                    string? info = infoRegex.Match(line).ToString();
                    string? warning = warnRegex.Match(line).ToString();
                    string? error = errorRegex.Match(line).ToString();
                    string? debug = debugRegex.Match(line).ToString();

                    if (infoRegex.IsMatch(line))
                        resultLogLine = resultLogLine.Replace(info, "INFO|");

                    if (warnRegex.IsMatch(line))
                        resultLogLine = resultLogLine.Replace(warning, "WARN|");

                    if (errorRegex.IsMatch(line))
                        resultLogLine = resultLogLine.Replace(error, "ERROR|");

                    if (debugRegex.IsMatch(line))
                        resultLogLine = resultLogLine.Replace(debug, "DEBUG|");

                    resultLogLine = resultLogLine.Replace("|", "\t");

                    resultLog.AppendLine(resultLogLine.ToString());
                    // return resultLogLine.ToString();
                }
                else
                {
                    resultLogLine.Replace(" INFORMATION ", $"\tINFO\t{callingMethod}")
                        .Replace(" WARNING ", $"\tWARN\t{callingMethod}")
                        .Replace(" ERROR ", $"\tERROR\t{callingMethod}")
                        .Replace(" DEBUG ", $"\tDEBUG\t{callingMethod}");

                    resultLog.AppendLine(resultLogLine.ToString());
                }

                const int correctNumberOfColumns = 5;
                if (resultLogLine.ToString().Split("\t").Length != correctNumberOfColumns)
                {
                    return originalLog;

                }
            }
            return resultLog.ToString().Split("\n");
        }
    }
}
