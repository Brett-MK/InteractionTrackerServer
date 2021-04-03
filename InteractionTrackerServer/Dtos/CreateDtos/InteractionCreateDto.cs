using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.CreateDtos
{
    public class InteractionCreateDto
    {
        [Key]
        public string CallId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public TimeWithUnitCreateDto Duration { get; set; }

        [Required]
        public TimeWithUnitCreateDto WaitingTime { get; set; }

        [Required]
        public AgentDataCreateDto AgentData { get; set; }

        [Required]
        public CallDataCreateDto CallData { get; set; }

        [Required]
        public IssueStatus IssueStatus { get; set; }

        [Required]
        public CustomerStatus CustomerStatus { get; set; }
    }
}
