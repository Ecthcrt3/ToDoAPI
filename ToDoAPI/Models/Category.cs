using System;
using System.Collections.Generic;

namespace ToDoAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            ToDos = new HashSet<ToDo>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
