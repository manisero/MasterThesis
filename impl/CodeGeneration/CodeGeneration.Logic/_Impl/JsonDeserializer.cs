namespace CodeGeneration.Logic._Impl
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public TResult Deserialize<TResult>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}
