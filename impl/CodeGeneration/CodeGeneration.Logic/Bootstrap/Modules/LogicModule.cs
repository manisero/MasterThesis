using CodeGeneration.Logic._Impl;
using Ninject.Modules;

namespace CodeGeneration.Logic.Bootstrap.Modules
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICodeGenerationFacade>().To<CodeGenerationFacade>();
            Bind<IFileSystemService>().To<FileSystemService>();
            Bind<IJsonDeserializer>().To<JsonDeserializer>();
        }
    }
}
