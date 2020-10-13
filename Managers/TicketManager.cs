using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ticketing_system_oop
{
    public interface TicketManager
    {
        public void readDisplayData(string file);
        
        //public Ticket elicitTicketInformation(string file);

        public void addTicket(string file);

        //public void writeTicketToFile(string file, Ticket ticket);

        //public Ticket readTicketInformation(string line);
        
        //public string calculateTicketID(string file);
    }
}