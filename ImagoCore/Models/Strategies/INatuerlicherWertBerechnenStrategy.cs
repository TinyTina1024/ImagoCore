using ImagoCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Strategies
{
    public interface INatuerlicherWertBerechnenStrategy
    {
        int berechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values);
    }
}
