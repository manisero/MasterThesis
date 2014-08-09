namespace CodeGeneration.Logic.DomainProcessing
{
    public interface IDomainSerializer
    {
        void Serialize<TDomain>(TDomain domain, string outputFilePath);
    }
}
