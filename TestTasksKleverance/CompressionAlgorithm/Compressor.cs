using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionAlgorithm
{
    public static class Compressor
    {
        public static string Compress(string? line)
        {
            ArgumentException.ThrowIfNullOrEmpty(line, nameof(line));

            StringBuilder compressedLine = new();
            int count = 1;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i].Equals(line[i + 1]))
                {
                    count++;
                }
                else
                {
                    if (count > 1)
                    {
                        compressedLine.Append(line[i] + count.ToString());
                        count = 1;
                    }

                    else compressedLine.Append(line[i]);
                    //if (i + 2 == line.Length)
                    //    compressedLine += line[i + 1];

                }
                if (i + 2 == line.Length && !line[i].Equals(line[i + 1]))
                    compressedLine.Append(line[i + 1]);

                if (i + 2 == line.Length && line[i].Equals(line[i + 1]))
                    compressedLine.Append(line[i] + count.ToString());
            }
            //var charArray = line.TakeWhile(x => x.Equals(l);
            //line.Contains(x)).ToArray();

            //var charArray = line.TakeWhile(x =>
            //line.Contains(x)).ToArray();

            // compressedLine = charArray[0] + charArray.Length.ToString();

            return compressedLine.ToString();
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
