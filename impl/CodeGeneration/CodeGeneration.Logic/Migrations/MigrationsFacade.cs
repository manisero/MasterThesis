using CodeGeneration.Logic.Bootstrap;
using CodeGeneration.Logic.Infrastructure;
using CodeGeneration.Logic.Migrations.ObjectComparison;
using Ninject;

namespace CodeGeneration.Logic.Migrations
{
    public static class MigrationsFacade
    {
        #region Dependencies resolution

        private class Dependencies
        {
            public IFileSystemService FileSystemService { get; private set; }
            public IJsonService JsonService { get; private set; }
            public IObjectComparer ObjectComparer { get; private set; }

            public Dependencies(IFileSystemService fileSystemService, IJsonService jsonService, IObjectComparer objectComparer)
            {
                FileSystemService = fileSystemService;
                JsonService = jsonService;
                ObjectComparer = objectComparer;
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

        public static Delta GetDelta<TSnapshot>(string snapshotPath, TSnapshot currentState)
        {
            var snapshotContent = GetDependencies().FileSystemService.GetFileContent(snapshotPath);
            var snapshot = GetDependencies().JsonService.Deserialize<TSnapshot>(snapshotContent);
            var delta = GetDependencies().ObjectComparer.Compare(snapshot, currentState);

            return delta;
        }
    }
}
