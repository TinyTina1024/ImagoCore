using ImagoCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models
{
    public static class ImagoEntitaetFactory
    {
        public static ImagoEntitaet GetNewEntitaet(Enumeration identifier)
        {
            SpielerBereich bereich = null;
            if (identifier is ImagoAttribut)
                bereich = SpielerBereich.Attribute;
            if (identifier is ImagoFertigkeit)
                bereich = SpielerBereich.Fertigkeiten;
            if (identifier is ImagoFertigkeitsKategorie)
                bereich = SpielerBereich.FertigkeitsKategorien;
            if (identifier is ImagoNichtSteigerbareFertigkeit)
                bereich = SpielerBereich.NichtSteigerbareFertigkeiten;
            if (identifier is ImagoKoerperTeil)
                bereich = SpielerBereich.Koerper;
            if(bereich == null)
                throw new ArgumentException();

            return new ImagoEntitaet(bereich, identifier);            
        }

        public static ImagoEntitaet GetRandomEntitaet()
        {
            var rand = new Random();
            var bereich = SpielerBereich.FromValue<SpielerBereich>(rand.Next(0, 5));
            Enumeration konkret = null;
            int count = 0;
            
            switch (bereich.Value)
            {                
                case 0: count = new List<ImagoAttribut>(ImagoAttribut.GetAll<ImagoAttribut>()).Count;                    
                    konkret = ImagoAttribut.FromValue<ImagoAttribut>(rand.Next(0, count)); break;
                case 1:
                    count = new List<ImagoFertigkeit>(ImagoFertigkeit.GetAll<ImagoFertigkeit>()).Count;                    
                    konkret = ImagoFertigkeit.FromValue<ImagoFertigkeit>(rand.Next(0, count)); break;
                case 2:
                    count = new List<ImagoFertigkeitsKategorie>(ImagoFertigkeitsKategorie.GetAll<ImagoFertigkeitsKategorie>()).Count;                    
                    konkret = ImagoFertigkeitsKategorie.FromValue<ImagoFertigkeitsKategorie>(rand.Next(0, count)); break;

                case 3:
                    count = new List<ImagoKoerperTeil>(ImagoKoerperTeil.GetAll<ImagoKoerperTeil>()).Count;                    
                    konkret = ImagoKoerperTeil.FromValue<ImagoKoerperTeil>(rand.Next(0, count)); break;
                case 4:
                    count = new List<ImagoNichtSteigerbareFertigkeit>(ImagoNichtSteigerbareFertigkeit.GetAll<ImagoNichtSteigerbareFertigkeit>()).Count;                    
                    konkret = ImagoNichtSteigerbareFertigkeit.FromValue<ImagoNichtSteigerbareFertigkeit>(rand.Next(0, count)); break;      
    }
            

            return new ImagoEntitaet(bereich, konkret);
        }
    }
}
