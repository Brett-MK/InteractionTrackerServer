using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class AgentData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AgentId { get; set; }

        [Required]
        public string AgentName { get; set; }

        [Required]
        public string AgentEmail { get; set; }
    }
}
