using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoFertigkeit : Enumeration
    {
        public static readonly ImagoFertigkeit Alchemie = new ImagoFertigkeit(0, "Alchemie");
        public static readonly ImagoFertigkeit Anatomie = new ImagoFertigkeit(1, "Anatomie");
        public static readonly ImagoFertigkeit Anfuehren = new ImagoFertigkeit(2, "Anführen");
        public static readonly ImagoFertigkeit Armbrueste = new ImagoFertigkeit(3, "Armbrüste");
        public static readonly ImagoFertigkeit Ausdruck = new ImagoFertigkeit(4, "Ausdruck");
        public static readonly ImagoFertigkeit Ausweichen = new ImagoFertigkeit(5, "Ausweichen");
        public static readonly ImagoFertigkeit Bewusstsein = new ImagoFertigkeit(6, "Bewusstsein");
        public static readonly ImagoFertigkeit Blasrohre = new ImagoFertigkeit(7, "Blasrohre");
        public static readonly ImagoFertigkeit Boegen = new ImagoFertigkeit(8, "Bögen");
        public static readonly ImagoFertigkeit Chaos = new ImagoFertigkeit(9, "Chaos");
        public static readonly ImagoFertigkeit Dolche = new ImagoFertigkeit(10, "Dolche");
        public static readonly ImagoFertigkeit Einfalt = new ImagoFertigkeit(11, "Einfalt");
        public static readonly ImagoFertigkeit Einschuechtern = new ImagoFertigkeit(12, "Einschüchtern");
        public static readonly ImagoFertigkeit Ekstase = new ImagoFertigkeit(13, "Ekstase");
        public static readonly ImagoFertigkeit Empathie = new ImagoFertigkeit(14, "Empathie");
        public static readonly ImagoFertigkeit Gesellschafter = new ImagoFertigkeit(15, "Gesellschafter");
        public static readonly ImagoFertigkeit Hiebwaffen = new ImagoFertigkeit(16, "Hiebwaffen");
        public static readonly ImagoFertigkeit Heiler = new ImagoFertigkeit(17, "Heiler");
        public static readonly ImagoFertigkeit Klettern = new ImagoFertigkeit(18, "Klettern");
        public static readonly ImagoFertigkeit Koerperbeherrschung = new ImagoFertigkeit(19, "Körperbeherrschung");
        public static readonly ImagoFertigkeit Kontrolle = new ImagoFertigkeit(20, "Kontrolle");
        public static readonly ImagoFertigkeit Laufen = new ImagoFertigkeit(21, "Laufen");
        public static readonly ImagoFertigkeit Literatur = new ImagoFertigkeit(22, "Literatur");
        public static readonly ImagoFertigkeit Leere = new ImagoFertigkeit(23, "Leere");
        public static readonly ImagoFertigkeit Manipulation = new ImagoFertigkeit(24, "Manipulation");
        public static readonly ImagoFertigkeit Materie = new ImagoFertigkeit(25, "Materie");
        public static readonly ImagoFertigkeit Mathematik = new ImagoFertigkeit(26, "Mathematik");
        public static readonly ImagoFertigkeit Naturkunde = new ImagoFertigkeit(27, "Naturkunde");
        public static readonly ImagoFertigkeit Philosophie = new ImagoFertigkeit(28, "Philosophie");
        public static readonly ImagoFertigkeit Physik = new ImagoFertigkeit(29, "Physik");
        public static readonly ImagoFertigkeit Reiten = new ImagoFertigkeit(30, "Reiten");
        public static readonly ImagoFertigkeit Schilde = new ImagoFertigkeit(31, "Schilde");
        public static readonly ImagoFertigkeit Schleichen = new ImagoFertigkeit(32, "Schleichen");
        public static readonly ImagoFertigkeit Schleuder = new ImagoFertigkeit(33, "Schleuder");
        public static readonly ImagoFertigkeit Schwerter = new ImagoFertigkeit(34, "Schwerter");
        public static readonly ImagoFertigkeit Schwimmen = new ImagoFertigkeit(35, "Schwimmen");
        public static readonly ImagoFertigkeit Sicherheit = new ImagoFertigkeit(36, "Sicherheit");
        public static readonly ImagoFertigkeit SozialeAdaption = new ImagoFertigkeit(37, "Soziale Adaption");
        public static readonly ImagoFertigkeit Soziologie = new ImagoFertigkeit(38, "Soziologie");
        public static readonly ImagoFertigkeit Sphaerologie = new ImagoFertigkeit(39, "Sphärologie");
        public static readonly ImagoFertigkeit Sprache = new ImagoFertigkeit(40, "Sprache");
        public static readonly ImagoFertigkeit Springen = new ImagoFertigkeit(41, "Springen");
        public static readonly ImagoFertigkeit SpurenLesen = new ImagoFertigkeit(42, "Spuren lesen");
        public static readonly ImagoFertigkeit StaebeSpeere = new ImagoFertigkeit(43, "Stäbe / Speere");
        public static readonly ImagoFertigkeit Strategie = new ImagoFertigkeit(44, "Strategie");
        public static readonly ImagoFertigkeit Struktur = new ImagoFertigkeit(45, "Struktur");
        public static readonly ImagoFertigkeit Tanzen = new ImagoFertigkeit(46, "Tanzen");
        public static readonly ImagoFertigkeit Taschendiebstahl = new ImagoFertigkeit(47, "Taschendiebstahl");
        public static readonly ImagoFertigkeit Verbergen = new ImagoFertigkeit(48, "Verbergen");
        public static readonly ImagoFertigkeit Verkleiden = new ImagoFertigkeit(49, "Verkleiden");
        public static readonly ImagoFertigkeit Verstecken = new ImagoFertigkeit(50, "Verstecken");
        public static readonly ImagoFertigkeit Waffenlos = new ImagoFertigkeit(51, "Waffenlos");
        public static readonly ImagoFertigkeit WirtschaftRecht = new ImagoFertigkeit(52, "Wirtschaft / Recht");
        public static readonly ImagoFertigkeit Wurfgeschosse = new ImagoFertigkeit(53, "Wurfgeschosse");
        public static readonly ImagoFertigkeit Wurfwaffen = new ImagoFertigkeit(54, "Wurfwaffen");
        public static readonly ImagoFertigkeit Wundscher = new ImagoFertigkeit(55, "Wundscher");
        public static readonly ImagoFertigkeit Zweihaender = new ImagoFertigkeit(56, "Zweihänder");

        public ImagoFertigkeit()
        {

        }

        private ImagoFertigkeit(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
