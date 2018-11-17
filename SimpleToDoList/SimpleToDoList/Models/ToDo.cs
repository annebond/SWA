using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList.Models
{
    public class ToDo
    {
        public ToDo(string description, bool done)
        {
            Description = description;
            Done = done;
        }

        public String Description { get; set; }
        public Boolean Done { get; set; }
    }
}
