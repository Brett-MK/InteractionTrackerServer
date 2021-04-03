using InteractionTrackerServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class CallDataReadDto
    {
        public int Id { get; set; }
        public string CallerName { get; set; }
        public string CallerNumber { get; set; }
        public string CcNumber { get; set; }
        public Direction Direction { get; set; }
    }
}
