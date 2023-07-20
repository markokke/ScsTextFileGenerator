using System;
using System.Collections.Generic;
using System.Text;

namespace ScsTextFileGenerator.Utilities
{
    public static class RandomGenerators
    {
        public static int GenerateRandomInteger(int fromRange, int toRange)
        {
            var random = new Random();
            if (toRange < fromRange)
            {
                throw new ArgumentOutOfRangeException("toRange < fromRange");
            }
            return random.Next(fromRange, toRange);
        }


        public static string GenerateRandomString(int stringLength, int ascIIStart, int ascIIEnd)
        {
            var random = new Random();

            if (stringLength < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                // 48 = 0, 57 = 9
                // 65 = A, 90 = Z
                // 97 = a, 122 = z
                char ch = (char)random.Next(ascIIStart, ascIIEnd);
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        public static DateTime GenerateRandomDateTime(DateTime fromDate, DateTime toDate)
        {
            var random = new Random();
            //var startDateTime = new DateTime(2019, 1, 1);
            //int range = (DateTime.Today - startDateTime).Days;
            //return startDateTime.AddDays(random.Next(range));

            TimeSpan range = new TimeSpan(toDate.Ticks - fromDate.Ticks);
            return fromDate + new TimeSpan((long)(range.Ticks * random.NextDouble()));
        }

        public static decimal GenerateDecimal()
        {
            var rand = new Random();
            var item = new decimal(rand.NextDouble());

            return item;
        }
    }
}
