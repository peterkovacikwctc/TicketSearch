using System;
using System.IO;

namespace ticketing_system_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketManager ticketManager;
            string file;
            
            Display display = new Display();
            display.welcomeMessage();
            
            string ticketChoice;
            do {
                display.chooseTicketTypeMessage();
                ticketChoice = Console.ReadLine();

                if (ticketChoice == "1") {
                    ticketManager = new BugManager();
                    file = "Tickets.csv";
                }
                else if (ticketChoice == "2") {
                    ticketManager = new EnhancementManager();
                    file = "Enhancements.csv";
                }
                else if (ticketChoice == "3") {
                    ticketManager = new TaskManager();
                    file = "Task.csv";
                }
                else {
                    file = "Error!";
                    ticketManager = new BugManager(); // for initialization
                    display.errorTicketTypeMessage();
                }
            } while (ticketChoice != "1" && ticketChoice != "2" && ticketChoice != "3");
            string menuChoice;

            do
            {
               display.menuOptions();
               menuChoice = Console.ReadLine(); 

               // read data from file
               if (menuChoice == "1") 
               {
                    // read data from file
                    if (File.Exists(file))
                    {
                        ticketManager.readDisplayData(file);
                        // display.ticketListMessage();

                        // StreamReader sr = new StreamReader(file);
                        
                        // // skip first line
                        // string line = sr.ReadLine();
                        
                        // while (!sr.EndOfStream)
                        // {
                        //     //Ticket ticket = new Ticket();
                        //     line = sr.ReadLine();
                        //     ticket = ticketManager.readTicketInformation(line);
                        //     display.displayTicketInfo(ticket);
                        // }
                        // sr.Close();
                    }
                    else
                    {
                        display.fileNotExistMessage();
                    }
               }
               
                // add Data to File
                else if (menuChoice == "2") 
                {
                    string response;
                        do 
                        {
                            display.shouldEnterTicket();
                            response = Console.ReadLine().ToUpper();
                            
                            // end loop if not adding ticket
                            if (response != "Y") { break; }

                            ticketManager.addTicket(file);
                            //Ticket ticket = new Ticket();
                            
                            
                            //ticket = ticketManager.elicitTicketInformation(file);
                            //ticketManager.addTicketToFile(file, ticket);

                        } while (response == "Y");
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
