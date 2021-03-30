using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Models
{
    public class TrafficByCustomerStatus
    {
        public string LowPriority { get; set; }

        public string VIP { get; set; }

        public string Normal { get; set; }
    }
}
