namespace LogFileStandardization.Tests.Unit
{
    public class LogFormatterTests
    {
        [Fact]
        public void Transform_log_entries_from_format1_to_a_new_format()
        {
            //arrange

            string format1 = "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'";
            var sut = new LogFormatter();

            // act
            string result =sut.Format(format1);

            //assert
            var newFormat = "2025-03-10\t15:14:49.523\tINFO\tDEFAULT\tВерсия программы: '3.4.0.48729'";
            Assert.Equal(newFormat, result);
        }
    }
}
