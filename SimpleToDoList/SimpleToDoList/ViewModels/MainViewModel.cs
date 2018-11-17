using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleToDoList.Commands;

namespace SimpleToDoList.ViewModels
{
    class MainViewModel
    {
        public String NewTaskDescription { get; set; }
        //list do store all values, observable is of type generic
        public ObservableCollection<ToDoVM> ToDoList{ get; set; }
        public RelayCommand AddBtnClickedCommand { get; set; }
        
        public MainViewModel()
        {
            NewTaskDescription = "";
            AddBtnClickedCommand = new RelayCommand(new Action(AddButtonClicked), new Func<bool>(CanExecute));
            ToDoList = new ObservableCollection<ToDoVM> {new ToDoVM("Some new Task", false), new ToDoVM("Another Task", true) };
            /* initializer instead of
            ToDoList.Add("Some new Task");
            ToDoList.Add("Another Task");
             */
        }

        private bool CanExecute()
        {
            return NewTaskDescription.Length > 0;
        }

        private void AddButtonClicked()
        {
            ToDoList.Add(new ToDoVM(NewTaskDescription, false));
        }
    }
}
