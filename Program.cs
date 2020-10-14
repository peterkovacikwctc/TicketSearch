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
                        } while (response == "Y");
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
