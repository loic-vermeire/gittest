using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using SC.BL;
using SC.BL.Domain;
using SC.UI.Web.MVC.Models;

namespace SC.UI.Web.MVC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketResponsesController : ControllerBase
    {
        private ITicketManager mgr = new TicketManager();

        [HttpGet]
        public IActionResult Get(int ticketNumber)
        {
            var responses = mgr.GetTicketResponses(ticketNumber);

            if (responses != null) return Ok(responses);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(NewTicketResponseDTO response)
        {
            TicketResponse createdResponse =
                mgr.AddTicketResponse(response.TicketNumber, response.ResponseText, response.IsClientResponse);

            if (createdResponse == null)
                return BadRequest("Er is iets misgelopen bij het registreren van het antwoord!");

            //return CreatedAtAction("GET", new {id = createdResponse.Id}, createdResponse); circulaire referenties!
            
            TicketResponseDTO responseData = new TicketResponseDTO()
            {
                Date = createdResponse.Date,
                Id = createdResponse.Id,
                IsClientResponse = createdResponse.IsClientResponse,
                Text = createdResponse.Text,
                TicketNumberOfTicket = createdResponse.Ticket.TicketNumber
            };
            
            return CreatedAtAction("GET", new {id = responseData.Id}, responseData);

        }
        
    }
    
    
    
}