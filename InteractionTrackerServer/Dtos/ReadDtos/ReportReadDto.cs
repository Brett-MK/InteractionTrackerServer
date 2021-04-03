using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class ReportReadDto
    {
        public int TotalInteractions { get; set; }
        public int IssuesResolved { get; set; }
        public TimeWithUnitReadDto TotalWaitTime { get; set; }
        public TimeWithUnitReadDto TotalDuration { get; set; }
        public TimeWithUnitReadDto AverageWaitTime { get; set; }
        public TrafficByCustomerStatusReadDto TrafficByCustomerStatus { get; set; }
    }
}
