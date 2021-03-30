using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class TrafficByCustomerStatus
    {
        public int LowPriority { get; set; }

        public int VIP { get; set; }

        public int Normal { get; set; }
    }
}
