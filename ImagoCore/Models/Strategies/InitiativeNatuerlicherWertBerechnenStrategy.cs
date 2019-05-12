using System;
using System.Collections.Generic;
using ImagoCore.Util;
using ImagoCore.Enums;

namespace ImagoCore.Models.Strategies
{
    public class InitiativeNatuerlicherWertBerechnenStrategy : INatuerlicherWertBerechnenStrategy
    {
        public int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            double geschicklichkeit, willenskraft, wahrnehmung;
            //Initiative = (Ge + Ge+ Wi + Wa)/4
            if (values.ContainsKey(ImagoAttribut.Geschicklichkeit) && values.ContainsKey(ImagoAttribut.Willenskraft) && values.ContainsKey(ImagoAttribut.Wahrnehmung))
            {
                geschicklichkeit = values[ImagoAttribut.Geschicklichkeit];
                willenskraft = values[ImagoAttribut.Willenskraft];
                wahrnehmung = values[ImagoAttribut.Wahrnehmung];


                var result = (geschicklichkeit + geschicklichkeit + willenskraft + wahrnehmung)/4;
                return MathHelper.KaufmaennischRunden(result);
            }

            throw new ArgumentException();
        }
    }
}
