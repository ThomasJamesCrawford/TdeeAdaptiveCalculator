using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TDEE
{
    public class WeightData
    {
        public IntervalList Intervals { get; set; }
        public List<TodoItem> Items { get; set; }
        public WeekList Weeks { get; set; }
        public WeightList Weights { get; set; }
        public WeightChangeList WeightChangeItems { get; set; }

        public WeightData()
        {
            Items = App.Items;

            Intervals = new IntervalList(UserSettings.WeeksInAvg, Items);

            Weeks = new WeekList(Intervals.List);

            Weights = new WeightList(Items);

            WeightChangeItems = new WeightChangeList(Weeks.List);
        }
    }
}
