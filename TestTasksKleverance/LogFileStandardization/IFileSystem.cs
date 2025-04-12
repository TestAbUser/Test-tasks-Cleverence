
namespace LogFileStandardization
{
    public interface IFileSystem
    {
        string[] Read(string path);
        void Write(string path, string[] text);
    }
}
