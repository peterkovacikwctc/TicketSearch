using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ticketing_system_oop
{
    public class TicketSelection {

        Display display = new Display();

        
        public string determineTicketChoice() {
            display.chooseTicketTypeMessage();
            string ticketChoice = Console.ReadLine();
            Console.WriteLine("");
            return ticketChoice;
        }
        
        public TicketManager determineManager(string ticketChoice) {
            
            TicketManager ticketManager;
            
            if (ticketChoice == "1") {
                    ticketManager = new BugManager();
            }
            else if (ticketChoice == "2") {
                ticketManager = new EnhancementManager();
            }
            else if (ticketChoice == "3") {
                ticketManager = new TaskManager();
            }
            else {
                ticketManager = new BugManager(); // for initialization
                display.errorTicketTypeMessage();
            }
            return ticketManager;
        }

        public string determineFile(string ticketChoice) {
            
            String file;

            if (ticketChoice == "1") {
                file = "Tickets.csv";
            }
            else if (ticketChoice == "2") {
                file = "Enhancements.csv";
            }
            else if (ticketChoice == "3") {
                file = "Task.csv";
            }
            else {
                file = "Error!";
            }

            return file;
        }
    }
}