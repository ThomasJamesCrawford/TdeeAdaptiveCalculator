using System;
using System.Collections.Generic;
using System.Linq;

namespace TDEE
{
    public class IntervalList
    {
        public List<IntervalGroupModel> List { get; set; } = new List<IntervalGroupModel>();

        public IntervalList(int interval, List<TodoItem> items)
        {
            if (items == null || interval <= 0 || items.Count <= 0)
            {
                return;
            }

            items.Sort((x, y) => x.Date.CompareTo(y.Date)); // order by date

            DateTime smallestDate = items.ElementAt(0).Date;
            IntervalGroupModel intervalGroup = new IntervalGroupModel();

            smallestDate = smallestDate.AddDays(interval);

            foreach (TodoItem item in items)
            {
                while (item.Date >= smallestDate && smallestDate <= items.ElementAt(items.Count - 1).Date)
                {
                    List.Add(intervalGroup);
                    intervalGroup = new IntervalGroupModel();
                    intervalGroup.Start = smallestDate;
                    smallestDate = smallestDate.AddDays(interval);
                }

                if (item.Date < smallestDate)
                {
                    if (List.Count == 0)
                    {
                        intervalGroup.Start = smallestDate.AddDays(-7);
                    }

                    intervalGroup.Items.Add(item);
                }
            }

            if (intervalGroup.Items.Count > 0)
            {
                List.Add(intervalGroup);
            }
        }
    }
}
