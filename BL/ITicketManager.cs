using System.Collections.Generic;
using SC.BL.Domain;

namespace SC.BL
{
    public interface ITicketManager
    {
        IEnumerable<Ticket> GetTickets();

        Ticket AddTicket(int accoutnId, string question);

        Ticket AddTicket(int accountId, string device, string problem);

        Ticket GetTicket(int ticketNumber);

        void ChangeTicket(Ticket ticket);

        void RemoveTicket(int ticketNumber);

        IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber);

        TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse);
    }
}