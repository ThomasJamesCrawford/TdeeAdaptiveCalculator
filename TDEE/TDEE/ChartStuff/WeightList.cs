using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class WeightList
    {
        public List<TodoItem> List { get; set; } = new List<TodoItem>();

        public WeightList(List<TodoItem> items)
        {
            if (items == null || items.Count == 0)
            {
                return;
            }

            foreach (TodoItem i in items)
            {
                if (i.Weight != 0)
                {
                    List.Add(i);
                }
            }
        }

        public WeightList(List<TodoItem> items, DateTime maxDate)
        {
            if (items == null || items.Count == 0 || maxDate == null)
            {
                return;
            }

            foreach (TodoItem i in items)
            {
                if (i.Date >= maxDate)
                {
                    break;
                }
                else if (i.Weight > 0 )
                {
                    List.Add(i);
                }
            }
        }

        public List<LineSeriesData> GetAsLineSeriesData()
        {
            if (List.Count == 0)
            {
                return new List<LineSeriesData>();
            }

            List<LineSeriesData> d = new List<LineSeriesData>(List.Count);

            foreach (TodoItem i in List)
            {
                d.Add(new LineSeriesData()
                {
                    YNumeric = i.Weight,
                    XDateTime = i.Date
                });
            }

            return d;
        }
    }
}
