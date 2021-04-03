using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class InteractionReadDto
    {
        public string CallId { get; set; }
        public DateTime Timestamp { get; set; }
        public TimeWithUnitReadDto Duration { get; set; }
        public TimeWithUnitReadDto WaitingTime { get; set; }
        public AgentDataReadDto AgentData { get; set; }
        public CallDataReadDto CallData { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
    }
}
