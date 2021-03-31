using InteractionTrackerServer.Data;
using InteractionTrackerServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteractionTrackerServer.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IInteractionRepo _interactionRepo;

        public ReportsController(IInteractionRepo interactionRepo)
        {
            _interactionRepo = interactionRepo;
        }

        // GET /api/reports/daily
        [HttpGet("daily")]
        public ActionResult<Report> GetDailyReport()
        {
            var interactionsToday = _interactionRepo.GetAllInteractions().Where(i => i.Timestamp >= DateTime.Today && i.Timestamp < DateTime.Today.AddDays(1));
            var todaysReport = GenerateReport(interactionsToday);

            return Ok(todaysReport);
        }

        // GET /api/reports/monthly
        [HttpGet("monthly")]
        public ActionResult<Report> GetMonthlyReport()
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            var interactionsThisMonth = _interactionRepo.GetAllInteractions().Where(i => i.Timestamp >= firstDayOfMonth && i.Timestamp < firstDayOfNextMonth);
            var thisMonthsReport = GenerateReport(interactionsThisMonth);

            return Ok(thisMonthsReport);
        }

        private Report GenerateReport(IQueryable<Interaction> interactions)
        {
            if (interactions.Count() == 0)
            {
                return new Report() { TotalWaitTime = new TimeWithUnit(), TotalDuration = new TimeWithUnit(), AverageWaitTime = new TimeWithUnit(), TrafficByCustomerStatus = new TrafficByCustomerStatus() };
            }

            return new Report()
            {
                TotalInteractions = interactions.Count(),
                TotalWaitTime = new TimeWithUnit() { Value = SumTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Minutes },
                TotalDuration = new TimeWithUnit() { Value = SumTimes(interactions.Select(x => x.Duration)), Unit = Unit.Minutes },
                AverageWaitTime = new TimeWithUnit() { Value = AverageTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Minutes },
                IssuesResolved = interactions.Count(i => i.IssueStatus == IssueStatus.Resolved),
                TrafficByCustomerStatus = new TrafficByCustomerStatus()
                {
                    LowPriority = interactions.Count(i => i.CustomerStatus == CustomerStatus.LowPriority),
                    Normal = interactions.Count(i => i.CustomerStatus == CustomerStatus.Normal),
                    VIP = interactions.Count(i => i.CustomerStatus == CustomerStatus.VIP),
                }
            };
        }

        private long SecondsConvert(int seconds) => TimeSpan.FromSeconds(seconds).Ticks;
        private long MinutesConvert(int minutes) => TimeSpan.FromMinutes(minutes).Ticks;
        private long MillisecondsConvert(int milliseconds) => TimeSpan.FromMilliseconds(milliseconds).Ticks;
        private long HoursConvert(int hours) => TimeSpan.FromHours(hours).Ticks;

        private int SumTimes(IEnumerable<TimeWithUnit> timeWithUnits)
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

        private int AverageTimes(IEnumerable<TimeWithUnit> timeWithUnits)
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
