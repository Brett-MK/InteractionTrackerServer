using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class CallData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CallerName { get; set; }

        [Required]
        public string CallerNumber { get; set; }

        [Required]
        public string CcNumber { get; set; }

        [Required]
        public Direction Direction { get; set; }
    }
}
