using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TDEE
{
    public class WeekList
    {
        public List<Week> List { get; set; } = new List<Week>();

        public WeekList(List<IntervalGroupModel> intervalGroups )
        {
            if (intervalGroups == null || intervalGroups.Count == 0)
            {
                return;
            }

            // assume the list is sorted to save time
            //intervalGroups.Sort((x, y) => x.Start.CompareTo(y.Start));

            foreach (IntervalGroupModel intervalGroup in intervalGroups)
            {
                Week w = null;

                if (List.Count > 0)
                {
                    w = new Week(List.Last().AvgWeight());
                    w.Start = intervalGroup.Start;
                }

                foreach (TodoItem item in intervalGroup.Items)
                {
                    if (w == null)
                    {
                        w = new Week(item.Weight);
                        w.Start = intervalGroup.Start;
                    }

                    w.AddCal(item.Calories);
                    w.AddWeight(item.Weight);
                }

                List.Add(w);
            }
        }

        public WeekList() { }

        public void CropRange(int range)
        {
            if (range <= List.Count)
            {
                List = List.GetRange(0, range);
            }
        }

        public List<LineSeriesData> GetAsLineSeriesData()
        {
            if (List.Count == 0)
            {
                return new List<LineSeriesData>();
            }

            // +1 because we add extra week at the end 
            List<LineSeriesData> data = new List<LineSeriesData>(List.Count + 1);

            foreach (Week w in List)
            {
                LineSeriesData d = new LineSeriesData()
                {
                    YNumeric = (int)Math.Round(w.Tdee),
                    XDateTime = w.Start
                };

                data.Add(d);
            }

            Week finalWeek = List.ElementAt(List.Count - 1).Clone();

            LineSeriesData finalPoint = new LineSeriesData()
            {
                YNumeric = (int)Math.Round(finalWeek.Tdee),
                XDateTime = finalWeek.Start.AddDays(7)
            };

            data.Add(finalPoint);

            return data;
        }
    }
}
