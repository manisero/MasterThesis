using System;
using Newtonsoft.Json;

namespace CodeGeneration.Logic.Infrastructure._Impl
{
    public class JsonService : IJsonService
    {
        public object Deserialize(Type resultType, string json)
        {
            return JsonConvert.DeserializeObject(json, resultType);
        }

        public TResult Deserialize<TResult>(string json)
        {
            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public string Serialize(object @object)
        {
            return JsonConvert.SerializeObject(@object, Formatting.Indented);
        }
    }
}
