using System;
using System.IO;

namespace ticketing_system_oop
{
    public class Task  : Ticket  {

        public Task() {
           
        }
        public string projectName
        { get; set; }

        public string dueDate
        { get; set; }
    }
}