
using System.Text;

namespace CompressionAlgorithm
{
    public static class Compressor
    {
        public static string Compress(string? line)
        {
            ArgumentException.ThrowIfNullOrEmpty(line, nameof(line));

            StringBuilder compressedLine = new();
            char prevChar = line[0];
            int count = 0;
            foreach (var @char in line)
            {
                if (@char.Equals(prevChar))
                {
                    count++;
                }
                else
                {
                    compressedLine.Append(GetPartialResult(prevChar, count));
                    prevChar = @char;
                    count = 1;
                }
            }
            compressedLine.Append(GetPartialResult(prevChar, count));

            return compressedLine.Length < line.Length ?
                compressedLine.ToString() : line;

            static string GetPartialResult(char prevChar, int count) =>
         prevChar + (count > 1 ? count.ToString() : string.Empty);
        }

        public static string Decompress(string? line)
        {
            ArgumentException.ThrowIfNullOrEmpty(line, nameof(line));

            StringBuilder decompressedLine = new();
            string? number = default;
            foreach (var @char in line.Reverse())
            {
                if (char.IsLetter(@char))
                {
                    _ = int.TryParse(number, out int numb);

                    decompressedLine.Append(GetPartialResult(@char, numb));
                    number = default;
                }
                else if (char.IsDigit(@char))
                {
                    number = @char + number;
                }
            }

            static string GetPartialResult(char @char, int number) =>
                number == 0 ? new(@char, 1) : new(@char, number);

            return string.Concat(decompressedLine.ToString().Reverse());
        }
    }
}
