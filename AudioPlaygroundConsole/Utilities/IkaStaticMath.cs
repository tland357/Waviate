using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class IkaStaticMath
    {
        public static double Clamp(double x, double low, double high)
        {
            if (x < low) return low;
            if (x > high) return high;
            return x;
        }
        public static double ZigZagRepeat(double x)
        {
            double r = 1.0 - Math.Abs(2.0 - ((Math.Abs(x) + 1) % 4));
            return x < 0 ? -r : r;
        }
        public static double ZigZagAbs(double x)
        {
            return 1.0 - Math.Abs(2.0 - ((Math.Abs(x) + 1) % 4));
        }
    }

