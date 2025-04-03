namespace CompressionAlgorithm.Tests.Unit
{
    public class CompressionTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Line_is_empty_or_null(string? line)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            Compressor.Compress(line));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("abcdef")]
        public void Line_has_unique_letters(string line)
        {
            var compressedLine = Compressor.Compress(line);

            Assert.Equal(line, compressedLine);
        }

        [Fact]
        public void Line_has_several_consecutive_identical_letters()
        {
            const string line = "aaa";
            
            var compressedLine = Compressor.Compress(line);

            Assert.Equal("a3", compressedLine);
        }



    }
}


