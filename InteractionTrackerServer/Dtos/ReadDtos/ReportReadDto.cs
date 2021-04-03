using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class ReportReadDto
    {
        public long TotalInteractions { get; set; }
        public long IssuesResolved { get; set; }
        public TimeWithUnitReadDto TotalWaitTime { get; set; }
        public TimeWithUnitReadDto TotalDuration { get; set; }
        public TimeWithUnitReadDto AverageWaitTime { get; set; }
        public TrafficByCustomerStatusReadDto TrafficByCustomerStatus { get; set; }
    }
}
