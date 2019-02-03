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
                d = -1;
                return false;
            }

            if (s.Equals(""))
            {
                d = -1;
                return true;
            }

            return Double.TryParse(s, out d);
        }

        public static bool TryParse0(string s, out double d)
        {
            if (s == null || s.EndsWith("."))
            {
                d = 0;
                return false;
            }

            if (s.Equals(""))
            {
                d = 0;
                return true;
            }

            return Double.TryParse(s, out d);
        }
    }
}
