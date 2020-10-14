using System;
using System.IO;

namespace ticketing_system_oop
{
    public class Enhancement : Ticket  {
        
        public string software
        { get; set; }

        public string reason
        { get; set; }

        public string estimate
        { get; set; }
    }
}