using System;
using System.IO;

namespace ticketing_system_oop
{
    public class Ticket
    {
        public string ticketID 
        { get; set; }

        public string summary 
        { get; set; }

        public string status 
        { get; set; }

        public string priority 
        { get; set; }

        public string submitter 
        { get; set; }

        public string assigned 
        { get; set; }

        public string watching1 
        { get; set; }

        public string watching2 
        { get; set; }

        public string watching3 
        { get; set; }
    }
}