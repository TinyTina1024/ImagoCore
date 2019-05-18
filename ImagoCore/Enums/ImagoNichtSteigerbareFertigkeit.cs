using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoNichtSteigerbareFertigkeit : Enumeration
    {
        public static readonly ImagoNichtSteigerbareFertigkeit Initiative = new ImagoNichtSteigerbareFertigkeit(0, "Initiative", "Ini");
        public static readonly ImagoNichtSteigerbareFertigkeit EgoRegeneration = new ImagoNichtSteigerbareFertigkeit(1, "Egoregeneration", "EgoReg");
        public static readonly ImagoNichtSteigerbareFertigkeit SchadensModifikator = new ImagoNichtSteigerbareFertigkeit(2, "Schadensmodifikator", "SchadensMod");
        public static readonly ImagoNichtSteigerbareFertigkeit LastGrenze = new ImagoNichtSteigerbareFertigkeit(3, "Lastgrenze", "Lastgr");

        public ImagoNichtSteigerbareFertigkeit()
        {

        }

        private ImagoNichtSteigerbareFertigkeit(int value, string displayName, string abbreviation) : base(value, displayName, abbreviation )
        {

        }
    }
}
