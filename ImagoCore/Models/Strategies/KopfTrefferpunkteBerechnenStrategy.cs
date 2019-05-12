﻿using ImagoCore.Util;

namespace ImagoCore.Models.Strategies
{
    public class KopfTrefferpunkteBerechnenStrategy : ITrefferpunkteBerechnenStrategy
    {
        public int BerechneTrefferpunkte(int konstitution)
        {
            if (konstitution == 0)
                return 0;

            double result = (double)konstitution/10;

            return MathHelper.KaufmaennischRunden(result);
        }
    }
}
