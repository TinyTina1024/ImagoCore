using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoFertigkeitsKategorie : Enumeration
    {
        public static readonly ImagoFertigkeitsKategorie Bewegung = new ImagoFertigkeitsKategorie(0, "Bewegung", "Bew");
        public static readonly ImagoFertigkeitsKategorie Nahkampf = new ImagoFertigkeitsKategorie(1, "Nahkampf", "Nah");
        public static readonly ImagoFertigkeitsKategorie Heimlichkeit = new ImagoFertigkeitsKategorie(2, "Heimlichkeit", "Heim");
        public static readonly ImagoFertigkeitsKategorie Fernkampf = new ImagoFertigkeitsKategorie(3, "Fernkampf", "Fern");
        public static readonly ImagoFertigkeitsKategorie Webkunst = new ImagoFertigkeitsKategorie(4, "Webkunst", "Web");
        public static readonly ImagoFertigkeitsKategorie Wissenschaft = new ImagoFertigkeitsKategorie(5, "Wissenschaft", "Wiss");
        public static readonly ImagoFertigkeitsKategorie Handwerk = new ImagoFertigkeitsKategorie(6, "Handwerk", "Handw");
        public static readonly ImagoFertigkeitsKategorie Soziales = new ImagoFertigkeitsKategorie(7, "Soziales", "Soz");

        public ImagoFertigkeitsKategorie()
        {

        }
        private ImagoFertigkeitsKategorie(int value, string displayName, string abbreviation) : base(value, displayName, abbreviation )
        {

        }
    }
}
