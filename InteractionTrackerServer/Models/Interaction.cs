using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TalkDeskInterviewApp.Models
{
    public class Interaction
    {
        [Key]
        [Required]
        public string CallId { get; set; }

        [Required]
        public AgentData AgentData { get; set; }

        [Required]
        public CustomerStatus CustomerStatus { get; set; }
    }
}
