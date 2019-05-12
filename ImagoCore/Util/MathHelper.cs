using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Util
{
    public static class MathHelper
    {
        public static int KaufmaennischRunden(double input)
        {
            return Convert.ToInt32(Math.Round(input, 0, MidpointRounding.AwayFromZero));
        }

        
    }
}
