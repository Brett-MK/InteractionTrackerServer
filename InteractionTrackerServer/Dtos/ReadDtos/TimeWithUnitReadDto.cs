using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class TimeWithUnitReadDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public Unit Unit { get; set; }
    }
}
