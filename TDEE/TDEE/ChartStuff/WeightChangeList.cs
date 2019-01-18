using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TDEE
{
    public class WeightChangeList
    {
        public List<LineSeriesData> List { get; set; } = new List<LineSeriesData>();

        public WeightChangeList(List<Week> weeks)
        {
            if (weeks == null || weeks.Count == 0)
            {
                return;
            }

            List.Add(new LineSeriesData()
            {
                YNumeric = 0,
                XDateTime = weeks.ElementAt(0).Start
            });

            foreach (Week w in weeks)
            {
                List.Add(new LineSeriesData()
                {
                    YNumeric = w.AvgWeight() - w.LastWeekWeight,
                    XDateTime = w.Start.AddDays(7)
                });
            }
        }
    }
}
