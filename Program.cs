using System;
using System.IO;

namespace ticketing_system_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketManager ticketManager; // different manager for each ticket type (BugManager, EnhancementManager, TaskManager)
            // used to manage differences in ticket types and their corresponding methods

            string file; // name for .csv file
            
            Display display = new Display();
            display.welcomeMessage();
            
            string menuChoice;
            do
            {
                display.menuOptions(); // 1) read file, 2) add to file, or end program
                menuChoice = Console.ReadLine();

                // does not ask for type of ticket if ending the program
                if (menuChoice != "1" && menuChoice != "2") {
                    break;
                }
               
                string ticketChoice;
                do {
                    // ask user type of ticket (Bug/Defect, Enhancement, or Task)
                    display.chooseTicketTypeMessage();
                    ticketChoice = Console.ReadLine();
                    Console.WriteLine("");

                    // ticket selection determines manager type and file name
                    TicketSelection ticketSelection = new TicketSelection(); 
                    
                    // determine type of ticket manager (BugManager, EnhancementManager, TaskManager)
                    ticketManager = ticketSelection.determineManager(ticketChoice);
                    
                    // determine file name based on ticket type 
                    file = ticketSelection.determineFile(ticketChoice);

                } while (ticketChoice != "1" && ticketChoice != "2" && ticketChoice != "3"); // 3 valid choices corresponding to ticket types
                
               
               // read data from file
               if (menuChoice == "1") 
               {
                    if (File.Exists(file))
                    {
                        ticketManager.readDisplayData(file); // read and display data from file
                    }
                    else
                    {
                        display.fileNotExistMessage();
                    }
               }
               
                // add Data to File
                else if (menuChoice == "2") 
                {
                    string response = "Y";
                    int i = 0;
                    do 
                    {
                        // if user already entered ticket, ask if user wants to enter another ticket
                        if (i > 0) {
                            display.shouldEnterTicket();
                            response = Console.ReadLine().ToUpper();
                            Console.WriteLine("");
                        }
                        
                        // end loop if not adding ticket
                        if (response != "Y") { break; }

                        // adds ticket information to file
                        ticketManager.addTicket(file);

                        i++; // counter to see if user already entered ticket (i > 0)
                    } while (response == "Y");
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
