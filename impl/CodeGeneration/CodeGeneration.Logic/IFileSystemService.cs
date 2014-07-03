namespace CodeGeneration.Logic
{
    public interface IFileSystemService
    {
        string GetFileContent(string filePath);

        void SetFileContent(string filePath, string content);
    }
}
