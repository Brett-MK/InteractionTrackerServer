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
        private static Dictionary<Unit, Func<long, long>> _converters = new Dictionary<Unit, Func<long, long>>()
        {
            { Unit.Milliseconds, (long milliseconds) => milliseconds },
            { Unit.Seconds, (long seconds) => (long)TimeSpan.FromSeconds(seconds).TotalMilliseconds },
            { Unit.Minutes, (long minutes) => (long)TimeSpan.FromMinutes(minutes).TotalMilliseconds },
            { Unit.Hours, (long hours) => (long)TimeSpan.FromHours(hours).TotalMilliseconds }
        };

        public static long SumTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var millisecondsSum = 0L;
            foreach (var duration in timeWithUnits)
            {
                millisecondsSum += _converters[duration.Unit](duration.Value);
            }

            return millisecondsSum;
        }

        public static long AverageTimes(IEnumerable<TimeWithUnit> timeWithUnits)
        {
            var timeInMilliseconds = new List<long>();
            foreach (var duration in timeWithUnits)
            {
                timeInMilliseconds.Add(_converters[duration.Unit](duration.Value));
            }

            return (long)Math.Floor(timeInMilliseconds.Average());
        }
    }
}
