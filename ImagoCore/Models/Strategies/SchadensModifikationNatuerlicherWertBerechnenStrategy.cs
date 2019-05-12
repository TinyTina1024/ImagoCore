using System;
using System.Collections.Generic;
using ImagoCore.Util;
using ImagoCore.Enums;

namespace ImagoCore.Models.Strategies
{
    public class SchadensModifikationNatuerlicherWertBerechnenStrategy : INatuerlicherWertBerechnenStrategy
    {
        public int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            if (values.ContainsKey(ImagoAttribut.Staerke))
            {
                double staerke = values[ImagoAttribut.Staerke]; 

                var result = (staerke-50) / 20;
                
                return MathHelper.KaufmaennischRunden(result);
            }

            throw new ArgumentException();
        }
    }
}
