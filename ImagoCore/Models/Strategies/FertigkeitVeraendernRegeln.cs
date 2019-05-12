using ImagoCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Strategies
    {
    public static class FertigkeitVeraendernRegeln
    {
        public static readonly int[] ImagoFolge = { 2, 3, 5, 8, 12, 17, 23, 30, 38, 47 };

        public static int GetReduzierenKosten(SteigerbareFertigkeitBase fertigkeit)
        {
            if (fertigkeit is Models.Attribut)
                return GetReduzierenKostenAttribut(fertigkeit.SteigerungsWert);
           
            if (fertigkeit is FertigkeitsKategorie)
                return GetReduzierenKostenFertigkeitsKategorie(fertigkeit.SteigerungsWert);
            
            return GetReduzierenKostenFertigkeit(fertigkeit.SteigerungsWert);

            throw new ArgumentException();
        }

        public static int GetSteigernKosten(SteigerbareFertigkeitBase fertigkeit)
        {
            if (fertigkeit is Models.Attribut)
                return GetSteigernKostenAttribut(fertigkeit.SteigerungsWert);
            
            if (fertigkeit is FertigkeitsKategorie)
                return GetSteigernKostenFertigkeitsKategorie(fertigkeit.SteigerungsWert);
            
            return GetSteigernKostenFertigkeit(fertigkeit.SteigerungsWert);

            throw new ArgumentException();
        }

        private static int GetSteigernKostenAttribut(int steigerungsWert)
        {
            double steigerungsWertFaktisch = ((double)steigerungsWert / 10);
            var temp = ((int)Math.Floor(steigerungsWertFaktisch));

            var resultIndex = temp -3;
            if (resultIndex <= 0)
                resultIndex = 0;            
            
            int benoetigteErfahrungspunkte = ImagoFolge[resultIndex];
            return benoetigteErfahrungspunkte;
        }

        private static int GetReduzierenKostenAttribut(int steigerungsWert)
        {
            if (steigerungsWert == 0)
                return 0;
            return GetSteigernKostenAttribut(steigerungsWert - 1);
        }

        private static int GetSteigernKostenFertigkeit(int steigerungsWert)
        {
            double steigerungsWertFaktisch = (double)steigerungsWert / 15;
            var resultIndex = ((int)Math.Floor(steigerungsWertFaktisch) );
            if (resultIndex < 0)
                resultIndex = 0;
            int benoetigteErfahrungspunkte = ImagoFolge[resultIndex];
            return benoetigteErfahrungspunkte;
        }

        private static int GetReduzierenKostenFertigkeit(int steigerungsWert)
        {
            if (steigerungsWert == 0)
                return 0;
            return GetSteigernKostenFertigkeit(steigerungsWert - 1);
        }

        private static int GetSteigernKostenFertigkeitsKategorie(int steigerungsWert)
        {
            double steigerungsWertFaktisch = (double)steigerungsWert / 5;
            var resultIndex = ((int)Math.Floor(steigerungsWertFaktisch)) + 2;
            if (resultIndex < 0)
                resultIndex = 0;
            int benoetigteErfahrungspunkte = ImagoFolge[resultIndex];
            return benoetigteErfahrungspunkte;

        }

        private static int GetReduzierenKostenFertigkeitsKategorie(int steigerungsWert)
        {
            if (steigerungsWert == 0)
                return 0;
            return GetSteigernKostenFertigkeitsKategorie(steigerungsWert - 1);
        }
        
    }
}
