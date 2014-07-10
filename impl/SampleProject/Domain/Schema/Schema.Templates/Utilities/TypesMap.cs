using System.Collections.Generic;

namespace Schema.Templates.Utilities
{
    public static class TypesMap
    {
        private class DotNetType
        {
            public string Name { get; private set; }
            public bool IsStruct { get; private set; }

            public DotNetType(string name, bool isStruct = false)
            {
                Name = name;
                IsStruct = isStruct;
            }
        }

        private static IDictionary<string, DotNetType> _typesMap = new Dictionary<string, DotNetType>
            {
                { "text", new DotNetType("string") },
                { "timeuuid", new DotNetType("Guid", true) }
            };

        public static string GetDotNetType(string cassandraType, bool isNullable)
        {
            DotNetType type;

            if (_typesMap.TryGetValue(cassandraType, out type))
            {
                return type.IsStruct && isNullable
                           ? type.Name + "?"
                           : type.Name;
            }

            return cassandraType;
        }
    }
}
