

using System.Collections.Generic;
using System.Linq;

public static class ObjectExtension
    {
    public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
    {
        return original ?? Enumerable.Empty<T>();
    }
}

