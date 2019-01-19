using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class TodoItem
    {
        
        public double Weight { get; set; }
        public double Calories { get; set; }

        [PrimaryKey, Column("Date")]
        public DateTime Date { get; set; }

        public TodoItem(double weight, double cal, DateTime date)
        {
            this.Weight = weight;
            this.Calories = cal;
            this.Date = date;
        }

        override
        public string ToString ()
        {
            return Weight.ToString() + "kg , " + Calories.ToString() + "cal";
        }

        public TodoItem() {}
    }
}
