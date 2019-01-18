using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.SfChart.XForms;

namespace TDEE
{
    public class BasicChart : SfChart
    {
        public LineSeries LineSeries { get; set; }
        public LineSeries LineSeries2 { get; set; }

        public BasicChart()
        {
            DateTimeAxis primaryAxis = new DateTimeAxis()
            {
                Interval = 7,
            };

            NumericalAxis secondaryAxis = new NumericalAxis();

            LineSeries = new LineSeries()
            {
                DataMarker = new ChartDataMarker()
                {
                    ShowMarker = false,
                    ShowLabel = false,
                },
            };

            LineSeries2 = new LineSeries()
            {
                DataMarker = new ChartDataMarker()
                {
                    ShowMarker = true,
                    ShowLabel = true,
                },
            };

            PrimaryAxis = primaryAxis;
            SecondaryAxis = secondaryAxis;
            Series.Add(LineSeries);
            Series.Add(LineSeries2);
        }
    }
}
