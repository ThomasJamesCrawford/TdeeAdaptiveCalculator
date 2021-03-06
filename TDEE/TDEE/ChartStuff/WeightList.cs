﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                if (i.Weight > 0)
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

        public double SevenDayAvg()
        {
            if (List.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            int count = 0;

            DateTime range = List.ElementAt(List.Count - 1).Date.AddDays(-7);

            for (int i = List.Count - 1; i >= 0; i--)
            {
                TodoItem td = List.ElementAt(i);

                if (td.Date > range)
                {
                    sum += td.Weight;
                    count++;
                }
                else
                {
                    break;
                }
            }

            return sum / count;
        }
    }
}
