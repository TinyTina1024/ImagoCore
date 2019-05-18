using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoKoerperTeil : Enumeration
    {
        public static readonly ImagoKoerperTeil Kopf = new ImagoKoerperTeil(0, "Kopf", "Kopf");
        public static readonly ImagoKoerperTeil Torso = new ImagoKoerperTeil(1, "Torso", "Torso");
        public static readonly ImagoKoerperTeil ArmLinks = new ImagoKoerperTeil(2, "Arm links", "ArmL");
        public static readonly ImagoKoerperTeil ArmRechts = new ImagoKoerperTeil(3, "Arm rechts", "ArmR");
        public static readonly ImagoKoerperTeil BeinLinks = new ImagoKoerperTeil(4, "Bein links", "BeinL");
        public static readonly ImagoKoerperTeil BeinRechts = new ImagoKoerperTeil(5, "Bein rechts", "BeinR");


        public ImagoKoerperTeil()
        {

        }
        private ImagoKoerperTeil(int value, string displayName, string abbreviation ) : base(value, displayName, abbreviation)
        {

        }
    }
}
