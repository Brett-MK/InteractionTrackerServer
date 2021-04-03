using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Dtos.ReadDtos
{
    public class AgentDataReadDto
    {
        public int Id { get; set; }
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentEmail { get; set; }
    }
}
