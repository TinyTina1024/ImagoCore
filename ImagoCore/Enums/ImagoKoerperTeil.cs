using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoKoerperTeil : Enumeration
    {
        public static readonly ImagoKoerperTeil Kopf = new ImagoKoerperTeil(0, "Kopf");
        public static readonly ImagoKoerperTeil Torso = new ImagoKoerperTeil(1, "Torso");
        public static readonly ImagoKoerperTeil ArmLinks = new ImagoKoerperTeil(2, "Arm links");
        public static readonly ImagoKoerperTeil ArmRechts = new ImagoKoerperTeil(3, "Arm rechts");
        public static readonly ImagoKoerperTeil BeinLinks = new ImagoKoerperTeil(4, "Bein links");
        public static readonly ImagoKoerperTeil BeinRechts = new ImagoKoerperTeil(5, "Bein rechts");


        public ImagoKoerperTeil()
        {

        }
        public ImagoKoerperTeil(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
