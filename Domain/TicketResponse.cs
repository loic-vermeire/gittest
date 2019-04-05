using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.BL.Domain
{
    public class TicketResponse : IValidatableObject
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public bool IsClientResponse { get; set; }
        public string Text { get; set; }
        
        public Ticket Ticket { get; set; }
        
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Date <= Ticket.DateOpened)
            {
                errors.Add(new ValidationResult("Can't be before the date the ticket is created!", new string[] {"Date", "Ticket.DateOpened"}));
            }

            return errors;
        }
    }
}