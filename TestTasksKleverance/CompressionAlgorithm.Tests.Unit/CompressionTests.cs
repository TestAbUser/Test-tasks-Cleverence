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
        public void Line_has_groups_of_repeating_and_separate_letters()
        {
            const string Line = "abaaabaabccbbbd";
            
            var compressedLine = Compressor.Compress(Line);

            Assert.Equal("aba3ba2bc2b3d", compressedLine);
        }

        [Fact]
        public void Decompress_compressed_line()
        {

        }



    }
}


