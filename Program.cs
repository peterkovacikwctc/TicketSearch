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
                            Ticket ticket1 = new Ticket();
                            line = sr.ReadLine();
                            ticket1 = ticketManager.readTicketInformation(line);
                            display.displayTicketInfo(ticket1);
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
                    StreamWriter sw = new StreamWriter(file, append: true);

                    string response;
                        do 
                        {
                            response = ticketManager.shouldEnterTicket();
                            
                            // end loop if not adding ticket
                            if (response != "Y") { break; }

                            Ticket ticket2 = new Ticket();
                            ticket2 = ticketManager.elicitTicketInformation(ticket2);
                            ticketManager.addTicketToFile(ticket2);

                        } while (response == "Y");
                        //sw.Close();
                }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
