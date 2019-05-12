using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
   public class ImagoAttribut : Enumeration
     {
        public static readonly ImagoAttribut Staerke = new ImagoAttribut(0, "Stärke");
        public static readonly ImagoAttribut Geschicklichkeit = new ImagoAttribut(1, "Geschicklichkeit");
        public static readonly ImagoAttribut Konstitution = new ImagoAttribut(2, "Konstitution");
        public static readonly ImagoAttribut Intelligenz = new ImagoAttribut(3, "Intelligenz");
        public static readonly ImagoAttribut Willenskraft = new ImagoAttribut(4, "Willenskraft");
        public static readonly ImagoAttribut Charisma = new ImagoAttribut(5, "Charisma");
        public static readonly ImagoAttribut Wahrnehmung = new ImagoAttribut(6, "Wahrnehmung");
        
        public ImagoAttribut() { }
        private ImagoAttribut(int value, string displayName) : base(value, displayName) { }
    }
}
