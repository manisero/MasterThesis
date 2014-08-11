using CodeGeneration.Logic.Bootstrap;
using CodeGeneration.Logic.Infrastructure;
using Ninject;

namespace CodeGeneration.Logic
{
    public static class SnapshotFacade
    {
        #region Dependencies resolution

        private class Dependencies
        {
            public IJsonService JsonService { get; private set; }
            public IFileSystemService FileSystemService { get; private set; }

            public Dependencies(IJsonService jsonService, IFileSystemService fileSystemService)
            {
                JsonService = jsonService;
                FileSystemService = fileSystemService;
            }
        }

        private static Dependencies _dependencies;
        private static Dependencies GetDependencies()
        {
            if (_dependencies == null)
            {
                var kernel = new StandardKernel();
                new NinjectBootstrapper().Bootstarp(kernel);

                _dependencies = kernel.Get<Dependencies>();
            }

            return _dependencies;
        }

        #endregion

        public static void CreateSnapshot<TSnapshot>(TSnapshot snapshot, string outputFilePath)
        {
            var json = GetDependencies().JsonService.Serialize(snapshot);
            GetDependencies().FileSystemService.SetFileContent(outputFilePath, json);
        }
    }
}
