

using System;
using System.Collections.Generic;
using SC.BL;
using SC.BL.Domain;
using SC.UI.CA.ExtensionMethods;


namespace SC.UI.CA
{
    class Program
    {

        private static readonly ITicketManager mgr = new TicketManager();
        private static readonly Service srv = new Service();
        private static bool quit;
        
        static void Main(string[] args)
        {
            while (!quit)
            {
                ShowMenu();
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("=== HELPDESK - SUPPORT - CENTER ===");
            Console.WriteLine("===================================");
            Console.WriteLine("1) Toon alle tickets");
            Console.WriteLine("2) Toon details van een ticket");
            Console.WriteLine("3) Toon de antwoorden van een ticket");
            Console.WriteLine("4) Maak een nieuw ticket");
            Console.WriteLine("5) Geef een antwoord op een ticket");
            Console.WriteLine("0) Afsluiten");
            DetectMenuAction();
        }

        private static void DetectMenuAction()
        {
            bool inValidAction;
            do
            {
                inValidAction = false;
                Console.Write("Keuze: ");
                string input = Console.ReadLine();
                int action;
                if (int.TryParse(input, out action))
                {
                    switch (action)
                    {
                        case 1:
                            PrintAllTickets();
                            break;
                        case 2:
                            ActionShowTicketDetails();
                            break;
                        case 3:
                            ActionShowTicketResponses();
                            break;
                        case 4:
                            ActionCreateTicket();
                            break;
                        case 5:
                            ActionAddResponseToTicket();
                            break;
                        case 0:
                            quit = true;
                            return;
                        default:
                            Console.WriteLine("Geen geldige keuze!");
                            inValidAction = true;
                            break;
                    }
               }
            } while (inValidAction);
        }

        private static void ActionAddResponseToTicket()
        {
            Console.Write("Ticketnummer: ");
            int ticketNumber = Int32.Parse(Console.ReadLine());
            
            Console.Write("Antwoord: ");
            string response = Console.ReadLine();

            srv.AddTicketResponse(ticketNumber, response, false);
        }

        private static void ActionShowTicketResponses()
        {
            Console.Write("Ticketnummer: ");
            int ticketNumber = Int32.Parse(Console.ReadLine());

            IEnumerable<TicketResponse> responses =  srv.GetTicketResponses(ticketNumber);
            if (responses != null) PrintTicketResponses(responses);
        }

        private static void PrintTicketResponses(IEnumerable<TicketResponse> responses)
        {
            foreach (var response in responses)
            {
                Console.WriteLine(response.GetInfo());
            }
        }

        private static void ActionShowTicketDetails()
        {
            Console.Write("Ticketnummer: ");
            int ticketNumber = Int32.Parse(Console.ReadLine());
            Ticket ticket = mgr.GetTicket(ticketNumber);
            PrintTicketDetails(ticket);
        }

        private static void PrintTicketDetails(Ticket ticket)
        {
            Console.WriteLine("{0,-15}: {1}", "Ticket", ticket.TicketNumber);
            Console.WriteLine("{0,-15}: {1}", "Gebruiker", ticket.AccountID);
            Console.WriteLine("{0,-15}: {1:dd/MM/yyyy}", "Datum", ticket.DateOpened);
            Console.WriteLine("{0,-15}: {1}", "Status", ticket.State);

            if (ticket is HardwareTicket)
            {
                Console.WriteLine("{0,-15}: {1}","Toestel",((HardwareTicket)ticket).DeviceName);
            }
            
            Console.WriteLine("{0,-15}: {1}", "Vraag/Probleem", ticket.Text);
            
        }

        private static void PrintAllTickets()
        {
            foreach (var ticket in mgr.GetTickets())
            {
                Console.WriteLine(ticket.GetInfo());
            }
        }

        private static void ActionCreateTicket()
        {
            string device = "";
            Console.Write("Is het een hardware probleem (j/n)?");
            bool isHardWare = (Console.ReadLine().ToLower() == "j");

            if (isHardWare)
            {
                Console.Write("Naam van het toestel: ");
                device = Console.ReadLine();
            }
            
            Console.Write("Gebruikersnummer: ");
            int accountNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Probleem ");
            string probleem = Console.ReadLine();

            if (!isHardWare)
            {
                mgr.AddTicket(accountNumber, probleem);
            }
            else
            {
                mgr.AddTicket(accountNumber, device, probleem);
            }
        }
    }
}