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
            
            string menuChoice;
            do
            {
                display.menuOptions();
                menuChoice = Console.ReadLine();

                // does not ask for type of ticket if ending the program
                if (menuChoice != "1" && menuChoice != "2") {
                    break;
                }
               
                // ask user type of ticket (Bug/Defect, Enhancement, or Task)
                string ticketChoice;
                do {
                    display.chooseTicketTypeMessage();
                    ticketChoice = Console.ReadLine();

                    TicketSelection ticketSelection = new TicketSelection();
                    // determine type of ticket manager
                    ticketManager = ticketSelection.determineManager(ticketChoice);
                    // determine filename for that manager 
                    file = ticketSelection.determineFile(ticketChoice);
                } while (ticketChoice != "1" && ticketChoice != "2" && ticketChoice != "3"); // 3 valid choices corresponding to ticket types
                
               
               // read data from file
               if (menuChoice == "1") 
               {
                    if (File.Exists(file))
                    {
                        ticketManager.readDisplayData(file);
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

                        // adds ticket information to respective file
                        ticketManager.addTicket(file);
                    } while (response == "Y");
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
