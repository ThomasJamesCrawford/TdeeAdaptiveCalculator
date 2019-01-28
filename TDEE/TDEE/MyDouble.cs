using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public class MyDouble
    {
        public static bool TryParse(string s, out double d)
        {
            if (s == null || s.EndsWith("."))
            {
                d = 0;
                return false;
            }
            return Double.TryParse(s, out d);
        }
    }
}
