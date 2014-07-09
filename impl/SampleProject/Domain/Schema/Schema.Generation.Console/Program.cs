using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates.Database;
using Schema.Templates.DotNet;

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

            // Generate database code
            var keySpaceGenerationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\create_keyspace.cql";
            CodeGenerationFacade.GenerateCode(domain.KeySpace,
                                              new KeySpaceCreationTemplate(),
                                              keySpaceGenerationPath);

            var keySpaceDropPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\drop_keyspace.cql";
            CodeGenerationFacade.GenerateCode(domain.KeySpace,
                                              new KeySpaceDropTemplate(),
                                              keySpaceDropPath);

            var tablesGenerationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\create_tables.txt";
            CodeGenerationFacade.GenerateCode(views,
                                              new TablesCreationTemplate(),
                                              tablesGenerationPath);

            var tablesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\tables";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cql"),
                                              () => new ViewCreationTemplate(),
                                              tablesPath,
                                              new TemplateArgument { Name = "KeySpace", Value = domain.KeySpace.Name });

            var selectsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\dql";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cql", "select_"),
                                              () => new ViewSelectTemplate(),
                                              selectsPath,
                                              new TemplateArgument { Name = "KeySpace", Value = domain.KeySpace.Name });

            // Generate .Net code
            var entitiesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Entities";
            CodeGenerationFacade.GenerateCode(domain.Entities.ToCodeGenerationUnits("cs"),
                                              () => new EntityTemplate(),
                                              entitiesPath);

            var eventsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Events";
            CodeGenerationFacade.GenerateCode(domain.Events.ToCodeGenerationUnits("cs"),
                                              () => new EventTemplate(),
                                              eventsPath);

            var viewsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Views";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cs"),
                                              () => new ViewClassTemplate(),
                                              viewsPath);
        }
    }
}
