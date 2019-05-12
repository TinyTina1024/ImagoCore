using ImagoCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ImagoCore.Models.Strategies
{    
    public class FertigkeitVeraendernService : IFertigkeitVeraendernService
    {
        public void SteigereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit)
        {            
            var benoetigteEp = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);
            var vorhandeneEp = fertigkeit.Erfahrung;
            if (vorhandeneEp >= benoetigteEp)
            {
                fertigkeit.Erfahrung = fertigkeit.Erfahrung - benoetigteEp;
                fertigkeit.SteigerungsWert++;                
            }
        }

        public void ReduziereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit)
        {            
            if (fertigkeit.SteigerungsWert == 0)
                return;

            var benoetigteEp = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            fertigkeit.Erfahrung = fertigkeit.Erfahrung + benoetigteEp;
            fertigkeit.SteigerungsWert--;
        }

        [Obsolete("Attribute haben doch einen Steigerungswert")]
        private void SteigereAttribut(ref Attribut attribut)
        {
            var benoetigteEp = FertigkeitVeraendernRegeln.GetSteigernKosten(attribut);
            var vorhandeneEp = attribut.Erfahrung;
            if (vorhandeneEp >= benoetigteEp)
            {
                attribut.Erfahrung = attribut.Erfahrung - benoetigteEp;
                attribut.SteigerungsWert++;
            }
        }

        [Obsolete("Attribute haben doch einen Steigerungswert")]
        private void ReduziereAttribut(ref Attribut attribut)
        {
            if (attribut.NatuerlicherWert == 0)
                return;

            var benoetigteEp = FertigkeitVeraendernRegeln.GetSteigernKosten(attribut);

            attribut.Erfahrung = attribut.Erfahrung + benoetigteEp;
            attribut.SteigerungsWert--;
        }
    }

   
    
}
