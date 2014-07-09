using System.Collections.Generic;
using System.IO;

namespace CodeGeneration.Logic.Infrastructure._Impl
{
    public class FileSystemService : IFileSystemService
    {
        public string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void SetFileContent(string filePath, string content)
        {
            var directory = Path.GetDirectoryName(filePath);

            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(filePath, content);
        }

        public IReadOnlyList<string> GetFilesInDirectory(string directoryPath, bool recursive)
        {
            return Directory.GetFiles(directoryPath, "*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public IReadOnlyList<string> GetDirectoriresInDirectory(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath);
        }

        public string GetRelativePath(string parentPath, string childPath)
        {
            var fullParentPath = Path.GetFullPath(parentPath);
            var fullChildPath = Path.GetFullPath(childPath);

            return fullChildPath.Substring(fullParentPath.Length + 1);
        }

        public string CombinePaths(params string[] paths)
        {
            return paths[0] != null
                       ? Path.Combine(paths)
                       : null;
        }

        public string ChangeFileExtension(string filePath, string newExtension)
        {
            return Path.ChangeExtension(filePath, newExtension);
        }
    }
}
