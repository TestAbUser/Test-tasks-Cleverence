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
            string compressedLine =line;

           var charArray = line.TakeWhile(x => line.Contains(x)).ToArray();

                 compressedLine = charArray[0]+charArray.Length.ToString();
           
            return compressedLine;
        }
    }
}
