using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.CreateDtos
{
    public class TimeWithUnitCreateDto
    {
        [Required]
        public int Value { get; set; }

        [Required]
        public Unit Unit { get; set; }
    }
}
