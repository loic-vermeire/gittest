using System;
using System.Collections.Generic;
using System.Linq;
using SC.BL.Domain;

namespace SC.DAL
{
    public class TicketRepositoryHC : ITicketRepository
    {

        private List<Ticket> tickets;
        private List<TicketResponse> responses;

        public TicketRepositoryHC()
        {
            Seed();
        }

        private void Seed()
        {
            tickets = new List<Ticket>();
            responses = new List<TicketResponse>();
            
            //Create first ticket

            Ticket t1 = new Ticket()
            {
                TicketNumber = tickets.Count + 1,
                AccountID = 1,
                Text = "Ik kan mij niet aanmelden op de webmail",
                State = TicketState.Closed,
                DateOpened = new DateTime(2017, 9, 9, 13, 5, 59),
                Responses = new List<TicketResponse>()
            };
            tickets.Add(t1);
           
            TicketResponse t1r1 = new TicketResponse()
            {
                Date = new DateTime(2017, 9, 9, 13, 24, 48),
                Id = responses.Count + 1,
                IsClientResponse = false,
                Text = "Account was geblokkeerd",
                Ticket = t1
            };
            t1.Responses.Add(t1r1);
            responses.Add(t1r1);

            TicketResponse t1r2 = new TicketResponse()
            {
                Ticket = t1,
                Id = responses.Count + 1,
                Text = "Account terug in orde en nieuw paswoord ingesteld",
                Date = new DateTime(2017, 9, 9, 13, 29, 11),
                IsClientResponse = false
            };
            t1.Responses.Add(t1r2);
            responses.Add(t1r2);

            TicketResponse t1r3 = new TicketResponse()
            {
                Id = responses.Count + 1,
                Ticket = t1,
                Text = "Aanmelden gelukt en paswoord gewijzigd",
                Date = new DateTime(2017, 9, 10, 7, 22, 36),
                IsClientResponse = true
            };
            t1.Responses.Add(t1r3);
            responses.Add(t1r3);
            t1.State = TicketState.Closed;
            
            // Create second ticket with one response
            Ticket t2 = new Ticket()
            {
                TicketNumber = tickets.Count + 1,
                AccountID = 1,
                Text = "Geen internetverbinding",
                DateOpened = new DateTime(2017, 11, 5, 9, 45, 13),
                State = TicketState.Open,
                Responses = new List<TicketResponse>()
            };
            tickets.Add(t2);
            
            TicketResponse t2r1 = new TicketResponse()
            {
                Id = responses.Count + 1,
                Ticket = t2,
                Text = "Controleer of de kabel goed is aangesloten",
                Date = new DateTime(2017, 11, 5, 11, 25, 42),
                IsClientResponse = false
            };
            t2.Responses.Add(t2r1);
            responses.Add(t2r1);
            t2.State = TicketState.Answered;
            
            // Create hardware ticket without response
            HardwareTicket ht1 = new HardwareTicket()
            {
                TicketNumber = tickets.Count + 1,
                AccountID = 2,
                Text = "Blue screen!",
                DateOpened = new DateTime(2017, 12, 14, 19, 5, 2),
                State = TicketState.Open,
                DeviceName = "PC-123456"
            };
            tickets.Add(ht1);
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            ticket.TicketNumber = tickets.Count + 1;
            tickets.Add(ticket);
            return ticket;
        }

        public IEnumerable<Ticket> ReadTickets()
        {
            return tickets;
        }

        public Ticket ReadTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketResponse> ReadTicketResponses(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public TicketResponse CreateTicketResponse(TicketResponse ticketResponse)
        {
            throw new NotImplementedException();
        }
    }
}