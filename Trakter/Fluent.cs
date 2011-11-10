using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter
{
    public static class Fluent
    {
        public static long ToEpochTime(this DateTime dateTime)
        {
            TimeSpan timeSpan = (dateTime - new DateTime(1970, 1, 1));
            return (long)timeSpan.TotalSeconds;
        }
    }
}
