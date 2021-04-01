using InteractionTrackerServer.Data;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using InteractionTrackerServer.Utils;
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
                TotalWaitTime = new TimeWithUnit() { Value = InteractionTimeMathUtil.SumTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Minutes },
                TotalDuration = new TimeWithUnit() { Value = InteractionTimeMathUtil.SumTimes(interactions.Select(x => x.Duration)), Unit = Unit.Minutes },
                AverageWaitTime = new TimeWithUnit() { Value = InteractionTimeMathUtil.AverageTimes(interactions.Select(x => x.WaitingTime)), Unit = Unit.Minutes },
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
