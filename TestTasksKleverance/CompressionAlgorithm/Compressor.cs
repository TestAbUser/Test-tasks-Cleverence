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

            if (line[1].Equals(line[0]))
            {
                 compressedLine = line[0]+line.Length.ToString();
            }
            //for (int i=1;i<=line.Length;i++)
            //{
            //    if(line[i] == line[i-1])
            //    {

            //    }
            //}
            
           // string compressedString = line;
            return compressedLine;
        }
    }
}
