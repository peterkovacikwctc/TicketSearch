using System;
using System.IO;

namespace ticketing_system_oop
{
    public class TicketManager
    {
        public Ticket elicitTicketInformation() {
            
            Ticket ticket = new Ticket();

            // TicketID
            Console.WriteLine("What is the ticket ID?");
            ticket.ticketID = Console.ReadLine();

            // Summary
            Console.WriteLine("What is the summary?");
            ticket.summary = Console.ReadLine();
            
            // Status
            Console.WriteLine("What is the status?");
            ticket.status = Console.ReadLine();
            
            // Priority
            Console.WriteLine("What is the priority?");
            ticket.priority = Console.ReadLine();
            
            // Submitter
            Console.WriteLine("Who is the submitter?");
            ticket.submitter = Console.ReadLine();
            
            // Assigned
            Console.WriteLine("Who is assinged?");
            ticket.assigned = Console.ReadLine();
            
            // Watching 1
            Console.WriteLine("Who is the first person watching?");
            ticket.watching1 = Console.ReadLine();
            
            // Watching 2
            Console.WriteLine("Who is the second person watching?");
            ticket.watching2 = Console.ReadLine();
            
            // Watching 3
            Console.WriteLine("Who is the third person watching?");
            ticket.watching3 = Console.ReadLine();
            
            return ticket;
        }

        public void addTicketToFile(string file, Ticket ticket) {
            
            StreamWriter sw = new StreamWriter(file, append: true);

            // write line to file
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}|{7}|{8}", 
            ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
            ticket.submitter, ticket.assigned, ticket.watching1, 
            ticket.watching2, ticket.watching3);

            sw.Close();                     
        }

        public Ticket readTicketInformation(string line) {
            
            // convert line of data from file into array
            string[] ticketElements = line.Split(',', '|');
            
            // make new ticket and give it data
            Ticket ticket = new Ticket();
            ticket.ticketID = ticketElements[0];
            ticket.summary = ticketElements[1];
            ticket.status = ticketElements[2];
            ticket.priority = ticketElements[3];
            ticket.submitter = ticketElements[4];
            ticket.assigned = ticketElements[5];
            ticket.watching1 = ticketElements[6];
            ticket.watching2 = ticketElements[7];
            ticket.watching3 = ticketElements[8];

            return ticket;
        }
    }
}