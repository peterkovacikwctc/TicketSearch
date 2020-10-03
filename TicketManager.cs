using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ticketing_system_oop
{
    public class TicketManager
    {
        public Ticket elicitTicketInformation(string file) {
            
            Ticket ticket = new Ticket();

            // TicketID
            ticket.ticketID = calculateTicketID(file);

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

        // calculate ticket based on highest number ticket already in system
        private string calculateTicketID(string file) {
            
            // make list of ticket IDs
            List<UInt64> ticketIds = new List<UInt64>();
            
            StreamReader sr = new StreamReader(file);
    
            // skip first line
            sr.ReadLine();

            // go through file to populate list of IDs
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] ticketElements = line.Split(',', '|');
                ticketIds.Add(UInt64.Parse(ticketElements[0]));
            }
            sr.Close();

            // find max ID value in ID list and add 1 to current ticket
            UInt64 ticketID = ticketIds.Max() + 1;
            return (ticketID.ToString()); 
        }
    }
}