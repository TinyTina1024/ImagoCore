using System.Collections.Generic;
using ImagoCore.Util;
using ImagoCore.Enums;

namespace ImagoCore.Models.Strategies
{
    public class LastgrenzeBerechnenStrategy : INatuerlicherWertBerechnenStrategy
    {
        public int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            double staerke = values[ImagoAttribut.Staerke];
            double konst = values[ImagoAttribut.Konstitution];
            double result = (staerke + staerke + konst) / 10;

            return MathHelper.KaufmaennischRunden(result);

        }
    }
}
