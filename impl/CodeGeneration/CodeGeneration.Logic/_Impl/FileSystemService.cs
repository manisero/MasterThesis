using System.IO;

namespace CodeGeneration.Logic._Impl
{
    public class FileSystemService : IFileSystemService
    {
        public string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
