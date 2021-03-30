using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class Report
    {
        public int TotalInteractions { get; set; }
        public int TotalWaitTime { get; set; }
        public int TotalDuration { get; set; }
        public double AverageWaitTime { get; set; }
        public int IssuesResolved { get; set; }
        public TrafficByCustomerStatus TrafficByCustomerStatus { get; set; }
}
}
