using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication_WebAPI_Blazor.Shared
{
    internal class TodoItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Priority { get; set; }

        public bool isDone { get; set; }
    }
}
