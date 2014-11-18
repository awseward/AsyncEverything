using System;

namespace Utilities
{
    public static class RandomHelper
    {
        private static Random _instance = new Random(GetTicksNow());

        public static Random Instance { get { return _instance; } }

        private static int GetTicksNow()
        {
            var totalTicks = DateTime.Now.Ticks;
            var cappedTicks = totalTicks % int.MaxValue;

            return Convert.ToInt32(cappedTicks);
        }
    }
}
