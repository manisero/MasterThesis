namespace CodeGeneration.Logic
{
    public class CodeGenerationUnit<TMetadata>
    {
        public TMetadata Metadata { get; set; }

        public string OutputFileName { get; set; }
    }
}
