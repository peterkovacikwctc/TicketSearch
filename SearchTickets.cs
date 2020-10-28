using System;
using System.IO;

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
                searchType = "Error!";
                break;
            }

            return searchType;
        }
    }
}