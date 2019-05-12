using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class SpielerBereich : Enumeration
    {
        public static readonly SpielerBereich Attribute = new SpielerBereich(0, "Attribute");
        public static readonly SpielerBereich Fertigkeiten = new SpielerBereich(1, "Fertigkeiten");
        public static readonly SpielerBereich FertigkeitsKategorien = new SpielerBereich(2, "Fertigkeitskategorien");
        public static readonly SpielerBereich Koerper = new SpielerBereich(3, "Körper");
        public static readonly SpielerBereich NichtSteigerbareFertigkeiten = new SpielerBereich(4, "Nichtsteigerbare Fertigkeiten");

        public SpielerBereich()
        {

        }

        private SpielerBereich(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
