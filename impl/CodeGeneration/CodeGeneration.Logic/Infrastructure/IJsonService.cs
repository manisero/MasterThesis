using System;

namespace CodeGeneration.Logic.Infrastructure
{
    public interface IJsonService
    {
        object Deserialize(Type resultType, string json);

        TResult Deserialize<TResult>(string json);

        string Serialize(object @object);
    }
}
