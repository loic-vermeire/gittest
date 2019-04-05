using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SC.BL;
using SC.BL.Domain;
using SC.UI.Web.MVC.Models;

namespace SC.UI.Web.MVC.Controllers
{
    public class TicketController : Controller
    {
        private ITicketManager mgr;

        public TicketController()
        {
            mgr = new TicketManager();
        }

        // GET /ticket
        public IActionResult Index()
        {
            IEnumerable<Ticket> tickets =  mgr.GetTickets();
            
            return View(tickets);
        }

        public IActionResult Details(int id)
        {
            Ticket ticket = mgr.GetTicket(id);

            if (ticket.Responses != null)
            {
                ViewBag.Responses = ticket.Responses;
            }
            else
            {
                ViewBag.Responses = mgr.GetTicketResponses(ticket.TicketNumber);
            }
            
            return View(ticket);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Ticket ticket = mgr.GetTicket(id);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(int id, Ticket ticket)
        {
            if (!ModelState.IsValid) return View(ticket);
            
            mgr.ChangeTicket(ticket);
            return RedirectToAction("Details", "Ticket", new {id = ticket.TicketNumber});
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTicketVM vm)
        {
            Ticket newTicket = mgr.AddTicket(vm.AccId, vm.Problem);
            return RedirectToAction("Details", "Ticket", new {id = newTicket.TicketNumber});
        }

        public IActionResult Delete(int id)
        {
            Ticket ticket = mgr.GetTicket(id);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            mgr.RemoveTicket(id);
            return RedirectToAction("Index", "Ticket");
        }
    }
}