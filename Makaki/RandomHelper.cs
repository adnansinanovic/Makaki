using System;
using System.Collections.Generic;

namespace Makaki
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();

        public static int Next(int start, int end)
        {
            return Random.Next(start, end);
        }

        public static T List<T>(List<T> list)
        {
           return list[Random.Next(0, list.Count)];
        }

        public static DateTime Date(DateTime minDate = default(DateTime))
        {
            return Date(DateTime.Today.AddYears(-100), DateTime.Today);            
        }

        public static DateTime Date(DateTime minDate, DateTime maxDate)
        {
            int range = (maxDate - minDate).Days;
            return minDate.AddDays(Random.Next(range));
        }
    }
}
