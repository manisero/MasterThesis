using System;
using Newtonsoft.Json;

namespace CodeGeneration.Logic.Infrastructure._Impl
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public object Deserialize(Type resultType, string json)
        {
            return JsonConvert.DeserializeObject(json, resultType);
        }

        public TResult Deserialize<TResult>(string json)
        {
            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}
