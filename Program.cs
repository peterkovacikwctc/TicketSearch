using System;

namespace ticketing_system_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.welcomeMessage();
            
            string file = "Tickets.csv";
            string menuChoice;

            do
            {
               menu.menuOptions();
               menuChoice = Console.ReadLine(); 

               if (menuChoice == "1") {

               }
               else if (menuChoice == "2") {

               }
            } while (menuChoice == "1" || menuChoice == "2");

            Console.WriteLine("\nGoodbye.\n");
        }
    }
}
