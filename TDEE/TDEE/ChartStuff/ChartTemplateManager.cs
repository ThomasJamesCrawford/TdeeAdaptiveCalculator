using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class ChartTemplateManager
    {
        TdeeData TdeeData { get; set; }
        WeightData WeightData { get; set; }

        public BasicChart WeightChart { get => GetWeightChart(); }
        public BasicChart TdeeChart { get => GetTdeeChart(); }


        private BasicChart GetTdeeChart()
        {
            TdeeData = new TdeeData();
            return Chart_Template.TdeeChart(TdeeData.Weeks, TdeeData.AvgTdeeLineData);
        }

        private BasicChart GetWeightChart()
        {
            WeightData = new WeightData();
            return Chart_Template.WeightChart(WeightData.Weights, WeightData.WeightChangeItems);
        }

    }
}
