using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Strategies
{
    public interface ITrefferpunkteBerechnenStrategy
    {
        int BerechneTrefferpunkte(int konstitution);
    }
}
