using System.Collections.Generic;
using ToDo_App.Models;

namespace Todo.Models.ViewModels
{
    public class ToDoViewModel
    {
        public List<ToDoItem> ToDoList { get; set; }
        public ToDoItem ToDo { get; set; }
    }
}