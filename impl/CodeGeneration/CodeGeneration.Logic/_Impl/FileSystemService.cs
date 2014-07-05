using System.Collections.Generic;
using System.IO;

namespace CodeGeneration.Logic._Impl
{
    public class FileSystemService : IFileSystemService
    {
        public string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void SetFileContent(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public IEnumerable<string> GetFilesInDirectory(string directoryPath, bool recursive)
        {
            return Directory.GetFiles(directoryPath, "*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public string GetRelativePath(string parentPath, string childPath)
        {
            var fullParentPath = Path.GetFullPath(parentPath);
            var fullChildPath = Path.GetFullPath(childPath);

            return fullChildPath.Substring(fullParentPath.Length + 1);
        }

        public string CombinePaths(params string[] paths)
        {
            return Path.Combine(paths);
        }

        public string ChangeFileExtension(string filePath, string newExtension)
        {
            return Path.ChangeExtension(filePath, newExtension);
        }
    }
}
