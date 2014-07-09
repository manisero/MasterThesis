using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates;
using System.Linq;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var metadataPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Model";
            var tablesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\tables";
            var entitiesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Entities";
            var viewsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Views";

            var generationFacade = CodeGenerationFacade.GetInstance();
            var domain = generationFacade.DeserializeDomain<Domain>(metadataPath);

            var views = new DomainProcessor().GetViews(domain);

            generationFacade.GenerateFromMetadata(views.ToDictionary(x => x, x => x.Name + ".cql"), () => new ViewTableTemplate(), tablesPath);
            generationFacade.GenerateFromMetadata(domain.Entities.ToDictionary(x => x, x => x.Name + ".cs"), () => new EntityTemplate(), entitiesPath);
            generationFacade.GenerateFromMetadata(views.ToDictionary(x => x, x => x.Name + ".cs"), () => new ViewClassTemplate(), viewsPath);
        }
    }
}
