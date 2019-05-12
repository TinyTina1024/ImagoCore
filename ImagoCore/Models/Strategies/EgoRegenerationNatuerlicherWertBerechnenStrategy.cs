using System;
using System.Collections.Generic;
using ImagoCore.Enums;
using ImagoCore.Util;

namespace ImagoCore.Models.Strategies
{
    public class EgoRegenerationNatuerlicherWertBerechnenStrategy : INatuerlicherWertBerechnenStrategy
    {
        public int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            if (values.ContainsKey(ImagoAttribut.Willenskraft))
            {                
                double willenskraft = values[ImagoAttribut.Willenskraft];                

                var result = (willenskraft) / 5;
                return MathHelper.KaufmaennischRunden(result);
            }

            throw new ArgumentException();
        }
    }
}
