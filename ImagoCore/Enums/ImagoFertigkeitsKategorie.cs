using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoFertigkeitsKategorie : Enumeration
    {
        public static readonly ImagoFertigkeitsKategorie Bewegung = new ImagoFertigkeitsKategorie(0, "Bewegung");
        public static readonly ImagoFertigkeitsKategorie Nahkampf = new ImagoFertigkeitsKategorie(1, "Nahkampf");
        public static readonly ImagoFertigkeitsKategorie Heimlichkeit = new ImagoFertigkeitsKategorie(2, "Heimlichkeit");
        public static readonly ImagoFertigkeitsKategorie Fernkampf = new ImagoFertigkeitsKategorie(3, "Fernkampf");
        public static readonly ImagoFertigkeitsKategorie Webkunst = new ImagoFertigkeitsKategorie(4, "Webkunst");
        public static readonly ImagoFertigkeitsKategorie Wissenschaft = new ImagoFertigkeitsKategorie(5, "Wissenschaft");
        public static readonly ImagoFertigkeitsKategorie Handwerk = new ImagoFertigkeitsKategorie(6, "Handwerk");
        public static readonly ImagoFertigkeitsKategorie Soziales = new ImagoFertigkeitsKategorie(7, "Soziales");

        public ImagoFertigkeitsKategorie()
        {

        }
        private ImagoFertigkeitsKategorie(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
