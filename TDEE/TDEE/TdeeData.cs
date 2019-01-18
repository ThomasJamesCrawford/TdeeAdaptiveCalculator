using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace TDEE
{
    public class TdeeData
    {
        public IntervalList Intervals { get; set; }
        public List<TodoItem> Items { get; set; }
        public WeekList Weeks { get; set; }
        public AverageLineSeriesList AvgTdeeLineData { get; set; }
        public int Tdee { get => (int)AvgTdeeLineData.List.ElementAt(0).YNumeric; }

        public TdeeData()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            Items = App.Items;

            sw.Stop();

            Console.WriteLine("Time to retrieve items: " + sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            Intervals = new IntervalList(7, Items);
            sw.Stop();
            Console.WriteLine("Time to make interval list: " + sw.ElapsedMilliseconds);


            sw.Reset();
            sw.Start();
            Weeks = new WeekList(Intervals.List);
            sw.Stop();
            Console.WriteLine("Time to make week list: " + sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            AvgTdeeLineData = new AverageLineSeriesList(Weeks.List);
            sw.Stop();
            Console.WriteLine("Time to make average line series list: " + sw.ElapsedMilliseconds);
        }
    }
}
