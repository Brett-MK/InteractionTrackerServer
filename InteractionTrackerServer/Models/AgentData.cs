using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TalkDeskInterviewApp.Models
{
    public class AgentData
    {
        [Required]
        [Key]
        public string AgentId { get; set; }

        [Required]
        public string AgentName { get; set; }

        [Required]
        public string AgentEmail { get; set; }
    }
}
