using System;
using System.IO;

namespace ticketing_system_oop
{
    public class BugDefect : Ticket {

        public BugDefect() {
            ElicitTicketInfo elicit = new BugElicit();
        }
        
        public string severity
        { get; set; }
    }
}