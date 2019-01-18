using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace TDEE
{
    class Chart_Template
    {
        public static BasicChart WeightChart(WeightList weights, WeightChangeList weightChangeItems)
        {
            BasicChart chart = new BasicChart();

            chart.LineSeries.ItemsSource = weights.List;
            chart.LineSeries.XBindingPath = "Date";
            chart.LineSeries.YBindingPath = "Weight";
            chart.Title.Text = "Weight/Weekly Weight Change";

            NumericalAxis numericalAxis = new NumericalAxis();

            chart.LineSeries2.YAxis = numericalAxis;
            chart.LineSeries2.YAxis.OpposedPosition = true;
            chart.LineSeries2.ItemsSource = weightChangeItems.List;
            chart.LineSeries2.XBindingPath = "Date";
            chart.LineSeries2.YBindingPath = "Weight";

            return chart;
        }

        public static BasicChart TdeeChart(WeekList weeks, AverageLineSeriesList averageLineSeriesList)
        {
            WeekList copyWeeks = new WeekList()
            {
                List = new List<Week>(weeks.List)
            };

            if (weeks != null && weeks.List.Count > 0)
            {
                // add a duplicate of the last week so it has a line shown
                Week w = copyWeeks.List.ElementAt(copyWeeks.List.Count - 1).Clone();
                w.Start = w.Start.AddDays(7);
                copyWeeks.List.Add(w);
            }

            BasicChart chart = new BasicChart();

            chart.LineSeries.ItemsSource = copyWeeks.List;
            chart.LineSeries.XBindingPath = "Start";
            chart.LineSeries.YBindingPath = "Tdee";
            chart.Title.Text = "TDEE";

            chart.LineSeries2.ItemsSource = averageLineSeriesList.List;
            chart.LineSeries2.XBindingPath = "Time";
            chart.LineSeries2.YBindingPath = "Tdee";

            return chart;
        }
    }
}
