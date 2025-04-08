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
           // string compressedLine = line;
            var t =line.Select(x => x);
            string compressedLine = "";
            int count = 1;
            for(int i=0;i<line.Length-1;i++)
            {
                if (line[i].Equals(line[i+1]))
                {
                   count++;
                }
                else
                {
                    if(count>1)
                    {
                        compressedLine += line[i] + count.ToString();
                        count = 1;
                    }
                    
                    else compressedLine += line[i];
                        //if (i + 2 == line.Length)
                        //    compressedLine += line[i + 1];
                        
                }
                if (i + 2 == line.Length && !line[i].Equals(line[i+1]))
                    compressedLine += line[i + 1];

                if (i + 2 == line.Length && line[i].Equals(line[i + 1]))
                    compressedLine += line[i] + count.ToString();
            }
            //var charArray = line.TakeWhile(x => x.Equals(l);
            //line.Contains(x)).ToArray();

            //var charArray = line.TakeWhile(x =>
            //line.Contains(x)).ToArray();

            // compressedLine = charArray[0] + charArray.Length.ToString();

            return compressedLine;
        }
    }
}
