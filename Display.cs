using System;
using System.IO;

namespace ticketing_system_oop
{
    public class Display
    {
        public void welcomeMessage() => Console.WriteLine("Welcome to the ticketing system!");

        public void menuOptions() {
            Console.WriteLine("\n1) Read data from file.");
            Console.WriteLine("2) Create or append file from data.");
            Console.WriteLine("Enter any other key to exit.");
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

        public void displayTicketInfo(Ticket ticket) {
            Console.WriteLine("TicketID: {0}\n" + 
                "Summary: {1}\n" + 
                "Status: {2}\n" + 
                "Priority: {3}\n" +
                "Submitter: {4}\n" +
                "Assigned: {5}\n" +
                "Watching: {6}, {7}, {8}\n", 
                ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
                ticket.submitter, ticket.assigned, ticket.watching1, 
                ticket.watching2, ticket.watching3);
        }

        public void shouldEnterTicket() {
            Console.WriteLine("\nEnter a ticket (Y/N)?");
        }

       
    }
}