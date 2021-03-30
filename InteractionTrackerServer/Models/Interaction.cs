using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class Interaction
    {
        [Key]
        public string CallId { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public Duration Duration { get; set; }

        [Required]
        public WaitingTime WaitingTime { get; set; }

        [Required]
        public AgentData AgentData { get; set; }

        [Required]
        public CallData CallData { get; set; }

        [Required]
        public IssueStatus IssueStatus { get; set; }

        [Required]
        public CustomerStatus CustomerStatus { get; set; }
    }
}
