using ImagoCore.Enums;
using ImagoCore.Models;
using ImagoCore.Models.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagoCore.TestData
{
    public static class TestData
    {
        public static Spieler GetTestSpieler()
        {
            return CreateVintus();
        }

        public static Spieler GetTestSpieler( ImagoRasse rasse )
        {
            return GetTestSpieler();
        }

        private static Spieler CreateVintus()
        {
            var vintus = new Spieler( new FertigkeitVeraendernService() )
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Vintus",
                Rasse = ImagoRasse.Mensch
            };
            var rand = new Random();

            //zufaellige Werte initialisieren
            foreach ( var item in vintus.Attribute )
            {                
                item.SteigerungsWert = rand.Next( 40, 70 );
                item.Erfahrung = rand.Next( 0, 5 );
                item.Korrosion = rand.Next( 0, 15 );
            }
            foreach ( var kategorie in vintus.FertigkeitsKategorien )
            {                
                kategorie.Erfahrung = rand.Next( 0, 5 );

                foreach ( var fertigkeit in kategorie.Fertigkeiten )
                {
                    fertigkeit.Erfahrung = rand.Next( 0, 15 );
                }
            }

            return vintus;
        }
    }
}
