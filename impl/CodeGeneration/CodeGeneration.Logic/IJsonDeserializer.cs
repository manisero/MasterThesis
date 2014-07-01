namespace CodeGeneration.Logic
{
    public interface IJsonDeserializer
    {
        TResult Deserialize<TResult>(string json);
    }
}
