using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ticketing_system_oop
{
    public interface TicketManager
    {
        public void readDisplayData(string file);
        
        public void addTicket(string file);

        public List<Ticket> makeTicketList(string file);

    }
}