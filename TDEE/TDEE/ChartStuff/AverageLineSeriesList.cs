using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TDEE
{
    public class AverageLineSeriesList
    {
        public List<LineSeriesData> List { get; set; } = new List<LineSeriesData>();

        public AverageLineSeriesList(int periods, List<Week> weeks)
        {
            Setup(periods, weeks);
        }

        public AverageLineSeriesList(List<Week> weeks)
        {
            Setup(weeks.Count, weeks);
        }

        private void Setup(int periods, List<Week> weeks)
        {
            if (periods <= 0 || weeks == null || weeks.Count == 0)
            {
                return;
            }

            // max periods is every week
            if (periods > weeks.Count)
            {
                periods = weeks.Count;
            }

            int firstWeek = weeks.Count - periods;

            DateTime startDate = weeks.ElementAt(firstWeek).Start;
            DateTime endDate = weeks.ElementAt(weeks.Count - 1).Start.AddDays(7);

            int count = 0;
            double sum = 0;
            for (int i = firstWeek; i < weeks.Count; i++)
            {
                Week w = weeks.ElementAt(i);

                if (w.Tdee > 0)
                {
                    count++;
                    sum += w.Tdee;
                }
            }

            if (count == 0)
            {
                return;
            }

            int avg = ((int)(sum / count));

            List.Add(new LineSeriesData()
            {
                YNumeric = avg,
                XDateTime = startDate
            });

            List.Add(new LineSeriesData()
            {
                YNumeric = avg,
                XDateTime = endDate
            });
        }
    }
}
