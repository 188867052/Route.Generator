using System;

namespace Api
{
    public static class Extention
    {
        public static object GetDefaultValueByName(string typeName)
        {
            Type type = GetTypeByString(typeName);
            var defaultValue = DefaultForType(type);

            return defaultValue;
        }

        public static object DefaultForType(Type targetType)
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }

        public static Type GetTypeByString(string type)
        {
            switch (type.ToLower())
            {
                case "int":
                    return typeof(int);
                case "int?":
                    return typeof(int?);
                case "datetime":
                    return typeof(DateTime);
                case "datetime?":
                    return typeof(DateTime?);
                case "bool":
                    return typeof(bool);
                case "bool?":
                    return typeof(bool?);
                case "decimal":
                    return typeof(decimal);
                case "decimal?":
                    return typeof(decimal?);
             
                default:
                    throw new Exception("No Support Type.");
            }
        }
    }
}
