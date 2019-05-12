using ImagoCore.Enums;
using System.Collections.Generic;
using ImagoCore.Util;

namespace ImagoCore.Models.Strategies
{
    public class FertigkeitsKategorieNatuerlicherWertBerechnenStrategy : INatuerlicherWertBerechnenStrategy
    {
        public FertigkeitsKategorieNatuerlicherWertBerechnenStrategy(ImagoAttribut[] attributReferenzen)
        {
            AttributReferenzen = attributReferenzen;
        }

        public ImagoAttribut[] AttributReferenzen;
        
        public int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            double result = 0;
            foreach (var item in AttributReferenzen)
            {
                if(values.ContainsKey(item))
                    result += values[item];                
            }

            return MathHelper.KaufmaennischRunden(result/6);
        }
    }
}
