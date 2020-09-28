using System;
using System.IO;

namespace ticketing_system_oop
{
    public class TicketManager
    {
        public Ticket elicitTicketInformation(Ticket ticket) {
            // get ticket info from user and write to ticket
            
            // ---------------------------
            
            /*
            // TicketID
            Console.WriteLine("What is the ticket ID?");
            string ticketID = Console.ReadLine();

            // Summary
            Console.WriteLine("What is the summary?");
            string summary = Console.ReadLine();
            
            // Status
            Console.WriteLine("What is the status?");
            string status = Console.ReadLine();
            
            // Priority
            Console.WriteLine("What is the priority?");
            string priority = Console.ReadLine();
            
            // Submitter
            Console.WriteLine("Who is the submitter?");
            string submitter = Console.ReadLine();
            
            // Assigned
            Console.WriteLine("Who is assinged?");
            string assigned = Console.ReadLine();
            
            // Watching 1
            Console.WriteLine("Who is the first person watching?");
            string watching1 = Console.ReadLine();
            
            // Watching 2
            Console.WriteLine("Who is the second person watching?");
            string watching2 = Console.ReadLine();
            
            // Watching 3
            Console.WriteLine("Who is the third person watching?");
            string watching3 = Console.ReadLine();
            */
            
            return ticket;
        }

        public void addTicketToFile(Ticket ticket) {
            /*
            StreamWriter sw = new StreamWriter(file, append: true);

            // write line to file
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}|{7}|{8}", 
            ticketID, summary, status, priority, submitter, assigned, 
            watching1, watching2, watching3);

            // add line for formatting 
            Console.WriteLine("");
            sw.Close();  
            */        
        }

        public Ticket readTicketInformation(string line) {
            Ticket ticket = new Ticket();

            return ticket;
        }

        public string shouldEnterTicket() {
            Console.WriteLine("\nEnter a ticket (Y/N)?");
            return Console.ReadLine().ToUpper();
        }
    }
}