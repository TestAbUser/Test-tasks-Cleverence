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
            // Regex regex = new();
            string newLog = "";//new string[log.Length];
            //foreach (var item in log)
            //{
            var culture= CultureInfo.GetCultureInfo("ru-RU");
                if(DateOnly.TryParse(log, culture, out DateOnly date))
                {
                    newLog = log.Replace(log, date.ToString("o", CultureInfo.InvariantCulture));
                }
           // }
            return newLog;
        }
    }
}
