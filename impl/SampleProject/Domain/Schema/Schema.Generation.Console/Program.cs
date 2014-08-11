using System.Collections.Generic;
using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates.Database;
using Schema.Templates.Documentation;
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
            var generationUnits = new DomainProcessor().Process(domain);

            // Create domain snapshot
            var snapshotPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Snapshots\snapshot1.json";
            SnapshotFacade.CreateGenerationUnitsSnapshot(generationUnits, snapshotPath);

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
            CodeGenerationFacade.GenerateCode(generationUnits.Views,
                                              new TablesCreationTemplate(),
                                              tablesGenerationPath);

            var tablesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\ddl\tables";
            CodeGenerationFacade.GenerateCode(generationUnits.Views.ToCodeGenerationUnits("cql"),
                                              () => new ViewCreationTemplate(),
                                              tablesPath,
                                              new TemplateArgument { Name = "KeySpace", Value = domain.KeySpace.Name });

            var selectsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\database\dql";
            CodeGenerationFacade.GenerateCode(generationUnits.Views.ToCodeGenerationUnits("cql", "select_"),
                                              () => new ViewSelectTemplate(),
                                              selectsPath,
                                              new TemplateArgument { Name = "KeySpace", Value = domain.KeySpace.Name });

            // Generate .Net code
            var entitiesPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Entities";
            CodeGenerationFacade.GenerateCode(generationUnits.Entities.ToCodeGenerationUnits("cs"),
                                              () => new EntityTemplate(),
                                              entitiesPath);

            var eventsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Events";
            CodeGenerationFacade.GenerateCode(generationUnits.Events.ToCodeGenerationUnits("cs"),
                                              () => new EventTemplate(),
                                              eventsPath);

            var viewsPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\dotnet\Sample.Domain\Views";
            CodeGenerationFacade.GenerateCode(generationUnits.Views.ToCodeGenerationUnits("cs"),
                                              () => new ViewClassTemplate(),
                                              viewsPath);

            // Generate documentation
            var documentationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\documentation\documentation.html";
            CodeGenerationFacade.GenerateCode(domain.Entities,
                                              new DocumentationTemplate(),
                                              documentationPath);
        }
    }
}
