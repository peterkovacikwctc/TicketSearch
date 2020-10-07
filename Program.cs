using System;
using System.IO;

namespace ticketing_system_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            display.welcomeMessage();

            TicketManager ticketManager = new TicketManager();
            
            string file = "Tickets.csv";
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
                        display.ticketListMessage();

                        StreamReader sr = new StreamReader(file);
                        
                        // skip first line
                        string line = sr.ReadLine();
                        
                        while (!sr.EndOfStream)
                        {
                            Ticket ticket = new Ticket();
                            line = sr.ReadLine();
                            ticket = ticketManager.readTicketInformation(line);
                            display.displayTicketInfo(ticket);
                        }
                        sr.Close();
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

                            Ticket ticket = new Ticket();
                            ticket = ticketManager.elicitTicketInformation(file);
                            ticketManager.addTicketToFile(file, ticket);

                        } while (response == "Y");
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
