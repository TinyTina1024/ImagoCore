using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
   public class ImagoAttribut : Enumeration
     {
        public static readonly ImagoAttribut Staerke = new ImagoAttribut(0, "Stärke", "St");
        public static readonly ImagoAttribut Geschicklichkeit = new ImagoAttribut(1, "Geschicklichkeit", "Ge");
        public static readonly ImagoAttribut Konstitution = new ImagoAttribut(2, "Konstitution", "Ko");
        public static readonly ImagoAttribut Intelligenz = new ImagoAttribut(3, "Intelligenz", "In");
        public static readonly ImagoAttribut Willenskraft = new ImagoAttribut(4, "Willenskraft", "Wi");
        public static readonly ImagoAttribut Charisma = new ImagoAttribut(5, "Charisma", "Ch");
        public static readonly ImagoAttribut Wahrnehmung = new ImagoAttribut(6, "Wahrnehmung", "Wa");
        
        public ImagoAttribut() { }

        private ImagoAttribut(int value, string displayName, string abbreviation) : base(value, displayName, abbreviation) { }
    }
}
