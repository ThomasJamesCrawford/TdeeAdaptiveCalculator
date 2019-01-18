using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class ViewModelItem
    {
        public List<TodoItem> Data { get; set; }

        public ViewModelItem()
        {
            Data = new List<TodoItem>();

            Data.Add(new TodoItem(100, 4500, new DateTime()));
        }
    }
}
