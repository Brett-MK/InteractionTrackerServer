using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Utils
{
    public static class InteractionTimeMathUtil
    {
        private static long SecondsConvert(int seconds) => TimeSpan.FromSeconds(seconds).Ticks;
        private static long MinutesConvert(int minutes) => TimeSpan.FromMinutes(minutes).Ticks;
        private static long MillisecondsConvert(int milliseconds) => TimeSpan.FromMilliseconds(milliseconds).Ticks;
        private static long HoursConvert(int hours) => TimeSpan.FromHours(hours).Ticks;

        public static int SumTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var tickSum = 0L;
            foreach (var duration in timeWithUnits)
            {
                switch (duration.Unit)
                {
                    case Unit.Milliseconds:
                        tickSum += MillisecondsConvert(duration.Value);
                        break;
                    case Unit.Seconds:
                        tickSum += SecondsConvert(duration.Value);
                        break;
                    case Unit.Minutes:
                        tickSum += MinutesConvert(duration.Value);
                        break;
                    case Unit.Hours:
                        tickSum += HoursConvert(duration.Value);
                        break;
                }
            }

            return Convert.ToInt32(TimeSpan.FromTicks(tickSum).TotalMinutes);
        }

        public static int AverageTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var timeWithUnitsInTicks = new List<long>();
            foreach (var duration in timeWithUnits)
            {
                switch (duration.Unit)
                {
                    case Unit.Milliseconds:
                        timeWithUnitsInTicks.Add(MillisecondsConvert(duration.Value));
                        break;
                    case Unit.Seconds:
                        timeWithUnitsInTicks.Add(SecondsConvert(duration.Value));
                        break;
                    case Unit.Minutes:
                        timeWithUnitsInTicks.Add(MinutesConvert(duration.Value));
                        break;
                    case Unit.Hours:
                        timeWithUnitsInTicks.Add(HoursConvert(duration.Value));
                        break;
                }

            }

            return Convert.ToInt32(Math.Floor(TimeSpan.FromTicks((long)timeWithUnitsInTicks.Average()).TotalMinutes));
        }
    }
}
