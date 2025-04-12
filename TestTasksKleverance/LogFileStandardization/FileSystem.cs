using System.Text;

namespace LogFileStandardization
{
    public class FileSystem : IFileSystem
    {

        public string[] Read(string path)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));
            return File.ReadAllLines(path);
        }

        public void Write(string path, string[] text)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));
            File.WriteAllLines(path, text, Encoding.UTF8);
        }
    }
}
