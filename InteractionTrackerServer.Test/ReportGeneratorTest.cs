using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using InteractionTrackerServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Test
{
    [TestClass]
    public class ReportGeneratorTest
    {
        [TestMethod]
        public void ReportGenerator_SumsInteractionsCorrectly()
        {
            var expectedInteractions = new List<Interaction>()
            {
                new Interaction()
                {
                    WaitingTime = new TimeWithUnit() { Value = 50, Unit = Unit.Minutes },
                    Duration = new TimeWithUnit() { Value = 10, Unit = Unit.Seconds },
                    IssueStatus = IssueStatus.Resolved,
                    CustomerStatus = CustomerStatus.VIP
                },
                new Interaction()
                {
                    WaitingTime = new TimeWithUnit() { Value = 10, Unit = Unit.Hours },
                    Duration = new TimeWithUnit() { Value = 40, Unit = Unit.Minutes },
                    IssueStatus = IssueStatus.Pending,
                    CustomerStatus = CustomerStatus.LowPriority
                },
                new Interaction()
                {
                    WaitingTime = new TimeWithUnit() { Value = 2000, Unit = Unit.Seconds },
                    Duration = new TimeWithUnit() { Value = 5000, Unit = Unit.Milliseconds },
                    IssueStatus = IssueStatus.Resolved,
                    CustomerStatus = CustomerStatus.VIP
                }
            };

            var report = ReportGenerator.GenerateReport(expectedInteractions);

            Assert.AreEqual(41000000, report.TotalWaitTime.Value);
            Assert.AreEqual(2415000, report.TotalDuration.Value);
            Assert.AreEqual(13666666, report.AverageWaitTime.Value);
            Assert.AreEqual(2, report.IssuesResolved);
            Assert.AreEqual(3, report.TotalInteractions);
            Assert.AreEqual(1, report.TrafficByCustomerStatus.LowPriority);
            Assert.AreEqual(2, report.TrafficByCustomerStatus.VIP);
        }
    }
}
