using CodeGeneration.Logic.Infrastructure;

namespace CodeGeneration.Logic.DomainProcessing._Impl
{
    public class DomainSerializer : IDomainSerializer
    {
        private readonly IJsonService _jsonService;
        private readonly IFileSystemService _fileSystemService;

        public DomainSerializer(IJsonService jsonService, IFileSystemService fileSystemService)
        {
            _jsonService = jsonService;
            _fileSystemService = fileSystemService;
        }

        public void Serialize<TDomain>(TDomain domain, string outputFilePath)
        {
            var json = _jsonService.Serialize(domain);
            _fileSystemService.SetFileContent(outputFilePath, json);
        }
    }
}
