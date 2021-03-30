using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class Report
    {
        public string TotalInteractions { get; set; }
        public string TotalWaitTime { get; set; }
        public string TotalDuration { get; set; }
        public string AverageWaitTime { get; set; }
        public string IssuesResolved { get; set; }
        public TrafficByCustomerStatus TrafficByCustomerStatus { get; set; }
}
}
