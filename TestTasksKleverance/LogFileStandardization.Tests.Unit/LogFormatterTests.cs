using Microsoft.VisualBasic;
using System.Runtime;

namespace LogFileStandardization.Tests.Unit
{
    public class LogFormatterTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Format_log_entries(string originalFormat, string newFormat)
        {
            var sut = new LogFormatter();

            string result = sut.Format(originalFormat);

            Assert.Equal(newFormat, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'",

                    "2025-03-10\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "2025-03-10\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"
                },
                new object[]
                {
                    "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 WARNING Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 ERROR Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 DEBUG Версия программы: '3.4.0.48729'",

                    "2025-03-10\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "2025-03-10\t15:14:49.523\tWARN\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "2025-03-10\t15:14:49.523\tERROR\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "2025-03-10\t15:14:49.523\tDEBUG\tDEFAULT\tВерсия программы: '3.4.0.48729'"
                }
            };
    }
}
