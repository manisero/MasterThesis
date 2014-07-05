using System.Collections.Generic;

namespace CodeGeneration.Logic
{
    public interface IFileSystemService
    {
        string GetFileContent(string filePath);

        void SetFileContent(string filePath, string content);

        IEnumerable<string> GetFilesInDirectory(string directoryPath, bool recursive = true);

        string GetRelativePath(string parentPath, string childPath);

        string CombinePaths(params string[] paths);

        string ChangeFileExtension(string filePath, string newExtension);
    }
}
