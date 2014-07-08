namespace CodeGeneration.Logic.DomainDeserialization
{
    public interface IDomainDeserializer
    {
        TDomain Deserialize<TDomain>(string rootFolderPath)
            where TDomain : new();
    }
}
