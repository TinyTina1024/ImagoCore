using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoNichtSteigerbareFertigkeit : Enumeration
    {
        public static readonly ImagoNichtSteigerbareFertigkeit Initiative = new ImagoNichtSteigerbareFertigkeit(0, "Initiative");
        public static readonly ImagoNichtSteigerbareFertigkeit EgoRegeneration = new ImagoNichtSteigerbareFertigkeit(1, "Egoregeneration");
        public static readonly ImagoNichtSteigerbareFertigkeit SchadensModifikator = new ImagoNichtSteigerbareFertigkeit(2, "Schadensmodifikator");
        public static readonly ImagoNichtSteigerbareFertigkeit LastGrenze = new ImagoNichtSteigerbareFertigkeit(3, "Lastgrenze");

        public ImagoNichtSteigerbareFertigkeit()
        {

        }

        private ImagoNichtSteigerbareFertigkeit(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
