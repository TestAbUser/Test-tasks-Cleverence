using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileStandardization
{
    public interface IFileSystem
    {
        string Read(string path);
        void Write(string path, string text);
    }
}
