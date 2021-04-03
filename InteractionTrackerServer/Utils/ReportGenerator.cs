using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Utils
{
    public static class ReportGenerator
    {
        public static Report GenerateReport(IEnumerable<Interaction> interactions)
        {
            if (interactions.Count() == 0)
            {
                return new Report() { TotalWaitTime = new TimeWithUnit(), TotalDuration = new TimeWithUnit(), AverageWaitTime = new TimeWithUnit(), TrafficByCustomerStatus = new TrafficByCustomerStatus() };
            }

            return new Report()
            {
                TotalInteractions = interactions.Count(),
                TotalWaitTime = new TimeWithUnit() { Value = InteractionTimeMathUtil.SumTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Milliseconds },
                TotalDuration = new TimeWithUnit() { Value = InteractionTimeMathUtil.SumTimes(interactions.Select(x => x.Duration)), Unit = Unit.Milliseconds },
                AverageWaitTime = new TimeWithUnit() { Value = InteractionTimeMathUtil.AverageTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Milliseconds },
                IssuesResolved = interactions.Count(i => i.IssueStatus == IssueStatus.Resolved),
                TrafficByCustomerStatus = new TrafficByCustomerStatus()
                {
                    LowPriority = interactions.Count(i => i.CustomerStatus == CustomerStatus.LowPriority),
                    Normal = interactions.Count(i => i.CustomerStatus == CustomerStatus.Normal),
                    VIP = interactions.Count(i => i.CustomerStatus == CustomerStatus.VIP),
                }
            };
        }
    }
}
