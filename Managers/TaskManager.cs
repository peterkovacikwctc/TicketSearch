using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ticketing_system_oop
{
    public class TaskManager : TicketManager
    {
        public Task ticket;
        Display display = new Display();

        public TaskManager() {
            ticket = new Task();
        }

        public void readDisplayData(string file) {
            Console.WriteLine("\nList of Bug/Defect Tickets\n");
            StreamReader sr = new StreamReader(file);
            
            // skip first line
            string line = sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                //Ticket ticket = new Ticket();
                line = sr.ReadLine();
                ticket = readTicketInformation(line);
                display.displayTaskInfo(ticket);
            }
            sr.Close();
        }

        public void addTicket(string file) {
             ticket = elicitTicketInformation(file);
             writeTicketToFile(file, ticket);
         }
        private Task elicitTicketInformation(string file) {

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
            
            // Watching 
            Console.WriteLine("Who is watching?");
            ticket.watching = Console.ReadLine();
            
            // Project Name
            Console.WriteLine("What is the project name?");
            ticket.projectName = Console.ReadLine();

            // Due Date
            Console.WriteLine("What is the due date?");
            ticket.dueDate = Console.ReadLine();
            
            return ticket;
        }

        private void writeTicketToFile(string file, Task ticket) {
            
            StreamWriter sw = new StreamWriter(file, append: true);

            // write line to file
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", 
            ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
            ticket.submitter, ticket.assigned, ticket.watching, 
            ticket.projectName, ticket.dueDate);

            sw.Close();                     
        }

        private Task readTicketInformation(string line) {
            
            // convert line of data from file into array
            string[] ticketElements = line.Split(',', '|');
            
            // make new ticket and give it data
            //Ticket ticket = new Ticket();
            ticket.ticketID = ticketElements[0];
            ticket.summary = ticketElements[1];
            ticket.status = ticketElements[2];
            ticket.priority = ticketElements[3];
            ticket.submitter = ticketElements[4];
            ticket.assigned = ticketElements[5];
            ticket.watching = ticketElements[6];
            ticket.projectName = ticketElements[7];
            ticket.dueDate = ticketElements[8];
            
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

             UInt64 ticketID;
            // find max ID value in ID list and add 1 to current ticket
            try {
                ticketID = ticketIds.Max() + 1;
            } catch {
                ticketID = 1;
            }
            return (ticketID.ToString()); 
        }
    }
}