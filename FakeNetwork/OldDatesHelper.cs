using System;

namespace Utilities
{
    public static class OldDatesHelper
    {
        public static DateTime GetPastDateTime()
        {
            return GetPastDateTime(DateTime.Now);
        }

        public static DateTime GetPastDateTime(DateTime from)
        {
            var random = RandomHelper.Instance;
            var tSpan = TimeSpan.FromSeconds(random.Next(int.MaxValue));

            return from - tSpan;
        }
    }
}
