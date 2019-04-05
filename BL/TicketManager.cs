using System;
using System.Collections.Generic;
using System.Linq;
using SC.BL.Domain;
using SC.DAL;
using SC.DAL.EF;

namespace SC.BL
{
    public class TicketManager : ITicketManager
    {

        private readonly ITicketRepository repo;
        

        public TicketManager()
        {
            //repo = new TicketRepositoryHC();
            repo = new TicketRepository();
        }
        
        public IEnumerable<Ticket> GetTickets()
        {
            return repo.ReadTickets();
        }

        public Ticket GetTicket(int ticketNumber)
        {
            return repo.ReadTicket(ticketNumber);
        }

        public void ChangeTicket(Ticket ticket)
        {
            repo.UpdateTicket(ticket);
        }

        public void RemoveTicket(int ticketNumber)
        {
            repo.DeleteTicket(ticketNumber);
        }

        public IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber)
        {
            return repo.ReadTicketResponses(ticketNumber);
        }

        public TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse)
        {
            Ticket ticketToAddResponseTo = GetTicket(ticketNumber);

            if (ticketToAddResponseTo != null)
            {
                //Create new response
                TicketResponse newResponse = new TicketResponse()
                {
                    Date = DateTime.Now,
                    Text = response,
                    IsClientResponse = isClientResponse,
                    Ticket = ticketToAddResponseTo
                };

                //add response to ticket
                var responses = GetTicketResponses(ticketNumber);

                if (response != null)
                    ticketToAddResponseTo.Responses = responses.ToList();
                else
                    ticketToAddResponseTo.Responses = new List<TicketResponse>();

                ticketToAddResponseTo.Responses.Add(newResponse);
                
                //change state of ticket

                if (isClientResponse)
                    ticketToAddResponseTo.State = TicketState.ClientAnswer;
                else 
                    ticketToAddResponseTo.State = TicketState.Answered;
                
                //Save changes to repository
                repo.CreateTicketResponse(newResponse);
                repo.UpdateTicket(ticketToAddResponseTo);

                return newResponse;

            }
            else 
                throw new ArgumentException("Ticketnumber '" + ticketNumber + "' not found!");
        }

        public Ticket AddTicket(int accoutnId, string question)
        {
            Ticket ticket = new Ticket()
            {
                AccountID = accoutnId,
                Text = question,
                DateOpened = DateTime.Now,
                State = TicketState.Open
            };
            return repo.CreateTicket(ticket);
        }

        public Ticket AddTicket(int accountId, string device, string problem)
        {
            Ticket ticket = new HardwareTicket()
            {
                AccountID = accountId,
                Text = problem,
                DeviceName = device,
                State = TicketState.Open,
                DateOpened = DateTime.Now
            };
            return repo.CreateTicket(ticket);
        }
    }
}