using Microsoft.AspNetCore.Mvc;
using SC.BL;
using SC.BL.Domain;

namespace SC.UI.Web.MVC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        ITicketManager mgr = new TicketManager();
        
        [HttpPut("{id}/State/Closed")]
        public IActionResult PutTicketStateToClosed(int id)
        {
            Ticket ticket = mgr.GetTicket(id);

            if (ticket == null) return NotFound();

            ticket.State = TicketState.Closed;
            mgr.ChangeTicket(ticket);
            return NoContent();
        }
    }
}