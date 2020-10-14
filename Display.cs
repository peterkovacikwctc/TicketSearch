using System;
using System.IO;

namespace ticketing_system_oop
{
    public class Display
    {
        public void welcomeMessage() => Console.WriteLine("\nWelcome to the ticketing system!\n");

        public void chooseTicketTypeMessage() {
            Console.WriteLine("");
            Console.WriteLine("Choose Ticket Type: ");
            Console.WriteLine("1) Bug/Defect");
            Console.WriteLine("2) Enhancement");
            Console.WriteLine("3) Task");
        }

        public void menuOptions() {
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create or append file from data.");
            Console.WriteLine("Enter any other key to exit.");
        }

        public void errorTicketTypeMessage() {
            Console.WriteLine("Error. Please choose a valid ticket type.\n");
        }
        public void fileNotExistMessage() {
            Console.WriteLine("\nFile does not exist.");
        }

        public void exitMessage() {
            Console.WriteLine("Goodbye.\n");
        }

        public void ticketListMessage() {
              Console.WriteLine("\nList of Tickets\n");
        }

        // public void displayTicketInfo(Ticket ticket) {
        //     Console.WriteLine("TicketID: {0}\n" + 
        //         "Summary: {1}\n" + 
        //         "Status: {2}\n" + 
        //         "Priority: {3}\n" +
        //         "Submitter: {4}\n" +
        //         "Assigned: {5}\n" +
        //         "Watching: {6}, {7}, {8}\n", 
        //         ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
        //         ticket.submitter, ticket.assigned, ticket.watching1, 
        //         ticket.watching2, ticket.watching3);
        // }

         public void displayBugInfo(BugDefect ticket) {
            Console.WriteLine("TicketID: {0}\n" + 
                "Summary: {1}\n" + 
                "Status: {2}\n" + 
                "Priority: {3}\n" +
                "Submitter: {4}\n" +
                "Assigned: {5}\n" +
                "Watching: {6}\n" +
                "Severity: {7}\n", 
                ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
                ticket.submitter, ticket.assigned, ticket.watching, ticket.severity);
        }

         public void displayEnhancementInfo(Enhancement ticket) {
            Console.WriteLine("TicketID: {0}\n" + 
                "Summary: {1}\n" + 
                "Status: {2}\n" + 
                "Priority: {3}\n" +
                "Submitter: {4}\n" +
                "Assigned: {5}\n" +
                "Watching: {6}\n" +
                "Software: {7}\n" +                
                "Reason: {8}\n" +
                "Estimate: {9}\n", 
                ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
                ticket.submitter, ticket.assigned, ticket.watching, ticket.software,
                ticket.reason, ticket.estimate);
        }

        public void displayTaskInfo(Task ticket) {
            Console.WriteLine("TicketID: {0}\n" + 
                "Summary: {1}\n" + 
                "Status: {2}\n" + 
                "Priority: {3}\n" +
                "Submitter: {4}\n" +
                "Assigned: {5}\n" +
                "Watching: {6}\n" +
                "Project Name: {7}\n" +                
                "Due Date: {8}\n",
                ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
                ticket.submitter, ticket.assigned, ticket.watching, ticket.projectName,
                ticket.dueDate);
        }

        public void shouldEnterTicket() {
            Console.WriteLine("\nEnter a ticket (Y/N)?");
        }

       
    }
}