
using System.Text;

namespace CompressionAlgorithm
{
    public static class Compressor
    {
        public static string Compress(string? line)
        {
            ArgumentException.ThrowIfNullOrEmpty(line, nameof(line));
            //if (line.Length == 1)
            //    return line;
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
            for (int i = 0; i < line.Length; i++)
            {
                int j = 0;
                if (char.IsLetter(line[i]) && i + 1 < line.Length)
                {
                    j = i;
                    while (j < line.Length - 1 && char.IsDigit(line[j + 1]))
                    {
                        j++;
                    }
                }

                if (j > i)
                {
                    decompressedLine.Append(line[i], int.Parse(line.Substring(i + 1, j - i)));
                    i = j;
                }
                else
                {
                    j = 0;
                    decompressedLine.Append(line[i]);
                }
            }
            return decompressedLine.ToString();
        }
    }
}
