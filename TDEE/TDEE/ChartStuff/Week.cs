using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class Week
    {
        public double Weight { get; set; }
        public double Cal { get; set; }
        public int WeightCount { get; set; }
        public int CalCount { get; set; }

        public double LastWeekWeight { get; set; }
        public double Tdee { get => GetTdee(); }

        public DateTime Start { get; set; }

        public Week (double lastWeekWeight)
        {
            LastWeekWeight = lastWeekWeight;
        }

        public double AvgWeight()
        {
            return Weight / WeightCount;
        }

        public double AvgCal()
        {
            return Cal / CalCount;
        }

        private int GetTdee()
        {
            return (int)Math.Round((AvgCal() * 7 - (AvgWeight() - LastWeekWeight) * UserSettings.CaloriesPerUnit) / 7);
        }

        public void AddWeight (double weight)
        {
            if (weight > 0 )
            {
                WeightCount++;
                Weight += weight;
            }

        }

        public void AddCal (double cal)
        {
            if (cal > 0)
            {
                CalCount++;
                Cal += cal;
            }
        }

        public Week Clone()
        {
            Week w = new Week(LastWeekWeight)
            {
                Weight = Weight,
                Cal = Cal,
                WeightCount = WeightCount,
                CalCount = CalCount,
                Start = Start
            };

            return w;
        }


    }
}
