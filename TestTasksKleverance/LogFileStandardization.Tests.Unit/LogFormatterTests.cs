namespace LogFileStandardization.Tests.Unit
{
    public class LogFormatterTests
    {
        [Fact]
        public void Transform_log_entries_from_format1_to_a_new_format()
        {
            //arrange
            string format1 = "10.03.2025";
            var sut = new LogFormatter();

            // act
            string result =sut.Format(format1);

            //assert
            var newFormat = "2025-03-10";
            Assert.Equal(newFormat, result);
        }
    }
}
