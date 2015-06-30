using System;
using System.Collections.Generic;

namespace NServiceBus.Serializers.XML.XsdGenerator
{
    using System.Collections.Concurrent;

    static class ExtensionMethods
    {
        static ConcurrentDictionary<RuntimeTypeHandle, string> TypeToNameLookup = new ConcurrentDictionary<RuntimeTypeHandle, string>();
        public static string SerializationFriendlyName(this Type t)
        {
            return TypeToNameLookup.GetOrAdd(t.TypeHandle, typeHandle =>
            {
                var index = t.Name.IndexOf('`');
                if (index >= 0)
                {
                    var result = t.Name.Substring(0, index) + "Of";
                    var args = t.GetGenericArguments();
                    for (var i = 0; i < args.Length; i++)
                    {
                        result += args[i].SerializationFriendlyName();
                        if (i != args.Length - 1)
                        {
                            result += "And";
                        }
                    }

                    if (args.Length == 2)
                    {
                        if (typeof(KeyValuePair<,>).MakeGenericType(args[0], args[1]) == t)
                        {
                            result = "NServiceBus." + result;
                        }
                    }

                    return result;
                }
                return Type.GetTypeFromHandle(typeHandle).Name;
            });
        }
    }
}
