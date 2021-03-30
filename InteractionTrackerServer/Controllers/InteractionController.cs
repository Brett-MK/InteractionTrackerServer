using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkDeskInterviewApp.Controllers
{
    [ApiController]
    [Route("/api/interactions")]
    public class InteractionController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateInteraction([FromBody]Interaction interaction)
        {
            // Check if VIP client
            // If VIP client send email 

            return Ok();
        }
    }
}
