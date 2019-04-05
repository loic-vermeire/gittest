using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    internal static class SupportCenterDbInitializer
    {
        private static bool hasRunDuringAppExecution;
        public static void Initialize(SupportCenterDbContext context, bool dropCreateDB = false)
        {
            if (!hasRunDuringAppExecution)
            {
                if (dropCreateDB) context.Database.EnsureDeleted();
                if (context.Database.EnsureCreated()) Seed(context);
                hasRunDuringAppExecution = true;
            }
           
        }

        private static void Seed(SupportCenterDbContext context)
        {
            
            //Create first Ticket with Responses
            Ticket t1 = new Ticket()
            {
                AccountID = 1,
                Text = "Ik kan mij niet aanmelden op de webmail",
                State = TicketState.Open,
                DateOpened = new DateTime(2017, 9, 9, 13, 5, 59),
                Responses = new List<TicketResponse>()
            };
            context.Tickets.Add(t1);
            
            TicketResponse t1r1 = new TicketResponse()
            {
                Date = new DateTime(2017, 9, 9, 13, 24, 48),
                IsClientResponse = false,
                Text = "Account was geblokkeerd",
                Ticket = t1
            };
            t1.Responses.Add(t1r1);
            
            TicketResponse t1r2 = new TicketResponse()
            {
                Ticket = t1,
                Text = "Account terug in orde en nieuw paswoord ingesteld",
                Date = new DateTime(2017, 9, 9, 13, 29, 11),
                IsClientResponse = false
            };
            t1.Responses.Add(t1r2);
            
            TicketResponse t1r3 = new TicketResponse()
            {
                Ticket = t1,
                Text = "Aanmelden gelukt en paswoord gewijzigd",
                Date = new DateTime(2017, 9, 10, 7, 22, 36),
                IsClientResponse = true
            };
            t1.Responses.Add(t1r3);
            t1.State = TicketState.Closed;

            //Create second Ticket with Response
            Ticket t2 = new Ticket()
            {
                AccountID = 1,
                Text = "Geen internetverbinding",
                DateOpened = new DateTime(2017, 11, 5, 9, 45, 13),
                State = TicketState.Open,
                Responses = new List<TicketResponse>()
            };
            context.Tickets.Add(t2);
            
            TicketResponse t2r1 = new TicketResponse()
            {
                Ticket = t2,
                Text = "Controleer of de kabel goed is aangesloten",
                Date = new DateTime(2017, 11, 5, 11, 25, 42),
                IsClientResponse = false
            };
            t2.Responses.Add(t2r1);
            t2.State = TicketState.Answered;
            
            //Create HardwareTicket without Response
            HardwareTicket ht1 = new HardwareTicket()
            {
                AccountID = 2,
                Text = "Blue screen!",
                DateOpened = new DateTime(2017, 12, 14, 19, 5, 2),
                State = TicketState.Open,
                DeviceName = "PC-123456"
            };
            context.Tickets.Add(ht1);
            
            //save changes
            context.SaveChanges();
            
            //disconnect from context
            foreach (var entry in context.ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
        }
        
        
       
    }
}