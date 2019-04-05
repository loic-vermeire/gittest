using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.BL.Domain
{
    public class Ticket
    {
        public int AccountID { get; set; }
        public DateTime DateOpened { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Er zijn maximaal 100 tekens toegestaan")]
        public string Text { get; set; }
        [Key]
        public int TicketNumber { get; set; }
        public TicketState State { get; set; }
        
        public ICollection<TicketResponse> Responses { get; set; }
    }
}