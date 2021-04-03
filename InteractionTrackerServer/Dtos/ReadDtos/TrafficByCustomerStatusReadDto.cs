using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class TrafficByCustomerStatusReadDto
    {
        public int LowPriority { get; set; }

        public int VIP { get; set; }

        public int Normal { get; set; }
    }
}
