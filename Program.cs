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
                        while (!sr.EndOfStream)
                        {
                            
                        }
                    }
                    else
                    {
                        display.fileNotExistMessage();
                    }
               }
               
               // add Data to File
               else if (menuChoice == "2") {

               }
            } while (menuChoice == "1" || menuChoice == "2");

            display.exitMessage();
        }
    }
}
