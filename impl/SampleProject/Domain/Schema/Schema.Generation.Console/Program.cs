using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtain metadata
            var metadataPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Model";

            var domain = CodeGenerationFacade.DeserializeDomain<Domain>(metadataPath);
            var views = new DomainProcessor().GetViews(domain);

            // Generate code
            var tablesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\tables";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cql"), () => new ViewTableTemplate(), tablesPath);

            var entitiesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Entities";
            CodeGenerationFacade.GenerateCode(domain.Entities.ToCodeGenerationUnits("cs"), () => new EntityTemplate(), entitiesPath);

            var viewsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Views";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cs"), () => new ViewClassTemplate(), viewsPath);
        }
    }
}
