namespace CodeGeneration.Logic.DomainProcessing
{
    public interface IDomainDeserializer
    {
        TDomain Deserialize<TDomain>(string rootFolderPath)
            where TDomain : new();
    }
}
