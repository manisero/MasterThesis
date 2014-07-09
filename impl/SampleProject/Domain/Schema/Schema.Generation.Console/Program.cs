using System.Collections.Generic;
using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates;
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

            // Generate code
            var keySpaceGenerationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\create_keyspace.cql";
            CodeGenerationFacade.GenerateCode(domain.KeySpace,
                                              new KeySpaceCreationTemplate(),
                                              keySpaceGenerationPath);

            var keySpaceDropPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\drop_keyspace.cql";
            CodeGenerationFacade.GenerateCode(domain.KeySpace.Name,
                                              new KeySpaceDropTemplate(),
                                              keySpaceDropPath);

            var tablesGenerationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\create_tables.txt";
            CodeGenerationFacade.GenerateCode(views,
                                              new TablesCreationTemplate(),
                                              tablesGenerationPath);

            var tablesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\tables";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cql"),
                                              () => new ViewTableTemplate(),
                                              tablesPath,
                                              new TemplateArgument { Name = "KeySpace", Value = domain.KeySpace.Name });

            var entitiesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Entities";
            CodeGenerationFacade.GenerateCode(domain.Entities.ToCodeGenerationUnits("cs"),
                                              () => new EntityTemplate(),
                                              entitiesPath);

            var viewsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Views";
            CodeGenerationFacade.GenerateCode(views.ToCodeGenerationUnits("cs"),
                                              () => new ViewClassTemplate(),
                                              viewsPath);
        }
    }
}
