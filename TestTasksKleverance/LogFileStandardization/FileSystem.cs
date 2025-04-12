using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileStandardization
{
    public class FileSystem: IFileSystem
    {
        public string Read(string path)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));
            return File.ReadAllText(path);
        }

        public void Write(string path, string text)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));
            File.WriteAllText(path, text);
        }
    }
}
