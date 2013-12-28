using System;

namespace NameGeneration
{
    internal static class ThreadSafeRandom
    {
        private static readonly Random _rand = new Random();
        private static readonly Object lockObj = new Object();

        public static int Next(int minValue, int maxValue)
        {
            lock (lockObj)
            {
                return _rand.Next(minValue, maxValue);
            }
        }

        public static bool NextBool()
        {
            lock (lockObj)
            {
                return (_rand.NextDouble() > 0.5);
            }
        }
    }
}
