using Byte.Sized.Monkeys.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte.Sized.Monkeys.Pad.B.Core.Services
{
    public static class Mapper
    {
        public static int CountDay(MayanCalendarChallengeDto mayanCalanderDto)
        {

            List<DateTime> days = new List<DateTime>();
            int amount = 0;
            for(int i = 0; i < (mayanCalanderDto.EndDate - mayanCalanderDto.StartDate).TotalDays; i++)
            {
                days.Add(mayanCalanderDto.StartDate.AddDays(i));
            }
            
            foreach(DateTime day in days)
            {
                if (day.ToString("dddd", new CultureInfo("en-US")).Equals(mayanCalanderDto.Day)) amount++;
            }

            return amount;
        }

        public static string ConvertSymbols(string[] mayanString)
        {
            string commonString = string.Concat(mayanString
                  .Select(line => line.AsEnumerable())
                  .Aggregate((s, a) => s.Intersect(a))
                  .OrderBy(c => c));
            var common = commonString.ToHashSet();
            return String.Join("", common);
        }
    }
}
