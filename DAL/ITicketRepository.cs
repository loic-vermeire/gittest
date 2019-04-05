using System.Collections.Generic;
using SC.BL.Domain;


namespace SC.DAL
{
    public interface ITicketRepository
    {
        Ticket CreateTicket(Ticket ticket);

        IEnumerable<Ticket> ReadTickets();

        Ticket ReadTicket(int ticketNumber);

        void UpdateTicket(Ticket ticket);

        void DeleteTicket(int ticketNumber);

        IEnumerable<TicketResponse> ReadTicketResponses(int ticketNumber);

        TicketResponse CreateTicketResponse(TicketResponse ticketResponse);
    }
}