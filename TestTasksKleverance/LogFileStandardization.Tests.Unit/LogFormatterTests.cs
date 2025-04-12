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
            LogFormatter sut = new();

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

                    "10-03-2025\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "10-03-2025\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"
                },
                new object[]
                {
                    "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 WARNING Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 ERROR Версия программы: '3.4.0.48729'"+
                    "10.03.2025 15:14:49.523 DEBUG Версия программы: '3.4.0.48729'",

                    "10-03-2025\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "10-03-2025\t15:14:49.523\tWARN\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "10-03-2025\t15:14:49.523\tERROR\tDEFAULT\tВерсия программы: '3.4.0.48729'"+
                    "10-03-2025\t15:14:49.523\tDEBUG\tDEFAULT\tВерсия программы: '3.4.0.48729'"
                },

                new object[]
                {
                    "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'",

                    "10-03-2025\t15:14:51.5882\tINFO\tMobileComputer.GetDeviceId\tКод устройства: '@MINDEO-M40-D-410244015546'"
                },

                new object[]
                {
                    "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'"+
                    "2025-03-10 15:14:51.5882| WARN|31|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'"+
                    "2025-03-10 15:14:51.5882| ERROR|01|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'"+
                    "2025-03-10 15:14:51.5882| DEBUG|7|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'",

                    "10-03-2025\t15:14:51.5882\tINFO\tMobileComputer.GetDeviceId\tКод устройства: '@MINDEO-M40-D-410244015546'"+
                    "10-03-2025\t15:14:51.5882\tWARN\tMobileComputer.GetDeviceId\tКод устройства: '@MINDEO-M40-D-410244015546'"+
                    "10-03-2025\t15:14:51.5882\tERROR\tMobileComputer.GetDeviceId\tКод устройства: '@MINDEO-M40-D-410244015546'"+
                    "10-03-2025\t15:14:51.5882\tDEBUG\tMobileComputer.GetDeviceId\tКод устройства: '@MINDEO-M40-D-410244015546'"
                }

            };
    }
}
