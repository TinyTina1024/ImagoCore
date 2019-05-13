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
    }

   
    
}
