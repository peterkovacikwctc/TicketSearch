using System;
using NLog.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace ticketing_system_oop
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TicketManager ticketManager; // different manager for each ticket type (BugManager, EnhancementManager, TaskManager)
            // used to manage differences in ticket types and their corresponding methods

            // specifc managers needed to create lists and search for tickets
            BugManager bugManager = new BugManager();
            EnhancementManager enhancementManager = new EnhancementManager();
            TaskManager taskManager = new TaskManager();

            string file; // name for .csv file
            
            //specific file names
            string bugFile = "Tickets.csv";
            string enhancementFile = "Enhancments.csv";
            string taskFile = "Task.csv"; 


            Display display = new Display();
            display.welcomeMessage();
            
            string menuChoice;
            do
            {
                display.menuOptions(); // 1) read file, 2) add to file, 3) search tickets, or other key to end program
                menuChoice = Console.ReadLine();

                // breaks loop if ending the program
                if (menuChoice != "1" && menuChoice != "2"  && menuChoice != "3") {
                    break;
                }


                TicketSelection ticketSelection = new TicketSelection(); 
                string ticketChoice;

                // The following -if statement prevents having to select the type of ticket
                // for 3) search tickets. It is important to not have to select a type of ticket for 3)
                // because all ticket types are searched.

                if (menuChoice == "1" || menuChoice == "2") {
                    
                    // following -do loop is unnecessary for 3) search tickets
                    do {
                        // choose type of ticket
                        ticketChoice = ticketSelection.determineTicketChoice();
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
                }
                // search tickets
                else if (menuChoice == "3")
                {
                    
                    Console.WriteLine("Enter text to search: ");
                    string text = Console.ReadLine();
                    Console.WriteLine("");
                    
                    SearchTickets searchTickets = new SearchTickets();
                    
                    // determine search type: status, priority, or submitter
                    display.ticketSearchChoice();
                    string searchChoice = Console.ReadLine();
                    Console.WriteLine("");
                    string searchProperty;
                    searchProperty = searchTickets.determineSearchType(searchChoice);

                    // make lists of all ticket types
                    List<Ticket> bugList = bugManager.makeTicketList(bugFile);
                    List<Ticket> enhancementList = enhancementManager.makeTicketList(enhancementFile);
                    List<Ticket> taskList = taskManager.makeTicketList(taskFile);
                    
                    // append lists into a single list
                    List<Ticket> ticketList = bugList.Concat(enhancementList).Concat(taskList).ToList();

                    // change display color in terminal
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    // use Linq to search through list and then display results and number of matches
                        switch(searchProperty) 
                        {
                        case "status":
                            searchTickets.displayStatusSearch(ticketList, searchProperty, text);
                            break;
                        case "priority":
                            searchTickets.displayPrioritySearch(ticketList, searchProperty, text);
                            break;
                        case "submitter":
                            searchTickets.displaySubmitterSearch(ticketList, searchProperty, text);
                            break;
                        default:
                            Console.WriteLine("Error!");
                            break;
                        } 

                    // change display color back to white
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            } while (menuChoice == "1" || menuChoice == "2" || menuChoice == "3");

            display.exitMessage();
        }
    }
}
