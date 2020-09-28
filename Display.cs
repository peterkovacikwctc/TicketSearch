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

        public void fileNotExist() {
            Console.WriteLine("\nFile does not exist.");
        }
    }
}