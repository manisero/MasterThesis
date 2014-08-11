using System;

namespace CodeGeneration.Logic.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsPrimitive(this Type type)
        {
            if (type.IsPrimitive)
            {
                return true;
            }

            var nullableType = Nullable.GetUnderlyingType(type);

            if (nullableType != null && nullableType.IsPrimitive)
            {
                return true;
            }

            if (type == typeof(string))
            {
                return true;
            }

            return false;
        }
    }
}
