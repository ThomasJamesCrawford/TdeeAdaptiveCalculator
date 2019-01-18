using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class IntervalGroupModel
    {
        public DateTime Start { get; set; }
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
