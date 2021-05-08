using System;

namespace GideonMarket.Utils
{
    public static class StringHelper
    {
        public static bool IsEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            return false;
        }
    }
}
