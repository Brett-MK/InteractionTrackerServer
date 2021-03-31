using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class Report
    {
        public int TotalInteractions { get; set; }
        public int IssuesResolved { get; set; }
        public TimeWithUnit TotalWaitTime { get; set; }
        public TimeWithUnit TotalDuration { get; set; }
        public TimeWithUnit AverageWaitTime { get; set; }
        public TrafficByCustomerStatus TrafficByCustomerStatus { get; set; }
}
}
