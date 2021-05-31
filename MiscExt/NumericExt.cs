using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MightyElk.MiscExt
{
    public static class NumericExt
    {
        
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        public static double RadianToDegree(this double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        
    }
}
