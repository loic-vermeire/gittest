using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    public class TicketRepository : ITicketRepository
    {
        private SupportCenterDbContext context;

        public TicketRepository()
        {
            context = new SupportCenterDbContext();
            SupportCenterDbInitializer.Initialize(context, true);
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

        public IEnumerable<Ticket> ReadTickets()
        {    
            //Eager Loading
            IEnumerable<Ticket> allTickets = context.Tickets.Include(t => t.Responses).AsEnumerable();
            
            //Lazy Loading (Via proxies, zet navigation properties op virtual)
            //IEnumerable<Ticket> allTickets = context.Tickets.AsEnumerable();
            return allTickets;
        }

        public Ticket ReadTicket(int ticketNumber)
        {
            //Ticket ticket = context.Tickets.Single(t => t.TicketNumber == ticketNumber);
            Ticket ticket = context.Tickets.Find(ticketNumber);
            return ticket;
        }

        public void UpdateTicket(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            context.SaveChanges();
        }

        public void DeleteTicket(int ticketNumber)
        {
            Ticket ticket = context.Tickets.Find(ticketNumber);
            context.Tickets.Remove(ticket);
            context.SaveChanges();
        }

        public IEnumerable<TicketResponse> ReadTicketResponses(int ticketNumber)
        {   
            IEnumerable<TicketResponse> responses =
                context.TicketResponses.Where(r => r.Ticket.TicketNumber == ticketNumber).AsEnumerable();
            
            return responses;
            
            /*
            //Explicit Loading
            Ticket ticket = context.Tickets.Find(ticketNumber);
            context.Entry<Ticket>(ticket).Collection(t => t.Responses).Load();

            return ticket.Responses;
            */
        }

        public TicketResponse CreateTicketResponse(TicketResponse ticketResponse)
        {
            context.TicketResponses.Add(ticketResponse);
            context.SaveChanges();

            return ticketResponse;
        }
    }
}