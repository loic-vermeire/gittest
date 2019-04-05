using System;
using SC.BL.Domain;

namespace SC.UI.CA.ExtensionMethods
{
    internal static class ExstensionMethods
    {
        internal static string GetInfo(this Ticket ticket)
        {
            return String.Format("[{0}] {1} ({2} antwoorden)",
                ticket.TicketNumber, ticket.Text, 
                ticket.Responses == null ? 0 : ticket.Responses.Count);
        }

        internal static string GetInfo(this TicketResponse response)
        {
            return String.Format("{0:dd/MM/yyyy} {1}{2}", response.Date, response.Text, response.IsClientResponse ? " (client)":"");
        }
    }
}