using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Utils
{
    public static class InteractionTimeMathUtil
    {
        private static Dictionary<Unit, Func<int, long>> _converters = new Dictionary<Unit, Func<int, long>>()
        {
            { Unit.Milliseconds, (int milliseconds) => TimeSpan.FromMilliseconds(milliseconds).Ticks },
            { Unit.Seconds, (int seconds) => TimeSpan.FromSeconds(seconds).Ticks },
            { Unit.Minutes, (int minutes) => TimeSpan.FromMinutes(minutes).Ticks },
            { Unit.Hours, (int hours) => TimeSpan.FromHours(hours).Ticks }
        };

        public static int SumTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var tickSum = 0L;
            foreach (var duration in timeWithUnits)
            {
                tickSum += _converters[duration.Unit](duration.Value);
            }

            return Convert.ToInt32(TimeSpan.FromTicks(tickSum).TotalMilliseconds);
        }

        public static int AverageTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var timeWithUnitsInTicks = new List<long>();
            foreach (var duration in timeWithUnits)
            {
                timeWithUnitsInTicks.Add(_converters[duration.Unit](duration.Value));
            }

            return Convert.ToInt32(Math.Floor(TimeSpan.FromTicks((long)timeWithUnitsInTicks.Average()).TotalMilliseconds));
        }
    }
}
