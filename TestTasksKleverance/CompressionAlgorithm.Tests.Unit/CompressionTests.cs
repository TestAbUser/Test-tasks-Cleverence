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


    }
}
