using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SC.BL.Domain;

namespace SC.UI.CA
{
    public class ProgramForTesting
    {
        static void Main(string[] args)
        {
            Ticket ticket = new HardwareTicket
            {
                TicketNumber = 2, AccountID = 1, Text = "", DateOpened = DateTime.Now, State = TicketState.Open, DeviceName = "PC-4387"
            };

            TicketResponse response = new TicketResponse
            {
                Id = 1, Text = "response", IsClientResponse = true, Date = new DateTime(2019, 1, 1), Ticket = ticket
            };
            
            var errors = new List<ValidationResult>();
            Validator.ValidateObject(ticket, new ValidationContext(ticket), true);
            
            
            
        }
    }
}