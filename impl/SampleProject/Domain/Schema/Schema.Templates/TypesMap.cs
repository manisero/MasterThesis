using System.Collections.Generic;

namespace Schema.Templates
{
    public static class TypesMap
    {
        private static IDictionary<string, string> _typesMap = new Dictionary<string, string>
            {
                { "text", "string" },
                { "timeuuid", "Guid" }
            };

        public static string GetDotNetType(string cassandraType)
        {
            string result;

            if (_typesMap.TryGetValue(cassandraType, out result))
            {
                return result;
            }

            return cassandraType;
        }
    }
}
