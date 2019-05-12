using ImagoCore.Util;

namespace ImagoCore.Models.Strategies
{
    public class TorsoTrefferpunkteBerechnenStrategy : ITrefferpunkteBerechnenStrategy
    {
        public int BerechneTrefferpunkte(int konstitution)
        {
            if (konstitution == 0)
                return 0;

            double result = (double)konstitution / 5;

            return MathHelper.KaufmaennischRunden(result);
        }
    }
}
