using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleToDoList.Models;

namespace SimpleToDoList.ViewModels
{
    public class ToDoVM
    {
        private ToDo toDo;

        public string Description
        {
            get { return toDo.Description;}
            set { toDo.Description = value; }
        }

        public bool Done
        {
            get { return toDo.Done; }
            set { toDo.Done = value; }
        }

        public ToDoVM(string description, bool done)
        {
            toDo = new ToDo(description, done);
        }

    }
}
