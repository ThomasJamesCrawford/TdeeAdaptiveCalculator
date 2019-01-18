using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TDEE
{
    class Tdee_Math
    {
        public static double Get_Tdee()
        {
            TdeeData td = new TdeeData();

            if (td.AvgTdeeLineData.List.Count > 0)
            {
                return td.AvgTdeeLineData.List.ElementAt(0).YNumeric;
            }
            else
            {
                return 0;
            }
        }
    }
}
