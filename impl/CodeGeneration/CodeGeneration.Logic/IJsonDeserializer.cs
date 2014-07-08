using System;

namespace CodeGeneration.Logic
{
    public interface IJsonDeserializer
    {
        object Deserialize(Type resultType, string json);

        TResult Deserialize<TResult>(string json);
    }
}
