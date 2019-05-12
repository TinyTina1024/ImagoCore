using ImagoCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models
{
    public interface INwBerechenbar
    {
        void BerechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values);
    }
}
