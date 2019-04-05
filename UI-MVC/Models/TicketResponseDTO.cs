using System;

namespace SC.UI.Web.MVC.Models
{
    public class TicketResponseDTO
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public bool IsClientResponse { get; set; }
        public string Text { get; set; }
        public int TicketNumberOfTicket { get; set; }
       
    }
}