using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ticketing_system_oop
{
    public class SearchTickets {

        public string determineSearchType(string searchChoice) {
            
            string searchType;

            switch(searchChoice) 
            {
            case "1":
                searchType = "status";
                break;
            case "2":
                searchType = "priority";
                break;
            case "3":
                searchType = "submitter";
                break;
            default:
                searchType = "ticketID";
                break;
            }

            return searchType;
        }

        public void displayStatusSearch(List<Ticket> ticketList, string searchProperty, string text) {
            // display ticket properties that match
                    var ticketMatches = ticketList.Where(t => t.status.Contains(text));
                    foreach(Ticket t in ticketMatches)
                    {
                        Console.WriteLine($"  {t.status}");
                    } 

                    // display number of matches
                    var numberMatches = ticketList.Where(t => t.status.Contains(text)).Count();
                    Console.WriteLine($"There are {numberMatches} tickets with \"{text}\" in the property {searchProperty} title.");  
        }

        public void displayPrioritySearch(List<Ticket> ticketList, string searchProperty, string text) {
            // display ticket properties that match
                    var ticketMatches = ticketList.Where(t => t.priority.Contains(text));
                    foreach(Ticket t in ticketMatches)
                    {
                        Console.WriteLine($"  {t.priority}");
                    } 

                    // display number of matches
                    var numberMatches = ticketList.Where(t => t.priority.Contains(text)).Count();
                    Console.WriteLine($"There are {numberMatches} tickets with \"{text}\" in the property {searchProperty} title.");  
        }

        public void displaySubmitterSearch(List<Ticket> ticketList, string searchProperty, string text) {
            // display ticket properties that match
                    var ticketMatches = ticketList.Where(t => t.submitter.Contains(text));
                    foreach(Ticket t in ticketMatches)
                    {
                        Console.WriteLine($"  {t.submitter}");
                    } 

                    // display number of matches
                    var numberMatches = ticketList.Where(t => t.submitter.Contains(text)).Count();
                    Console.WriteLine($"There are {numberMatches} tickets with \"{text}\" in the property {searchProperty} title.");  
        }
    }
}