using ImagoCore.Enums;
using ImagoCore.Models.Events;
using ImagoCore.Models.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using static ImagoCore.Models.ImagoEntitaetFactory;

namespace ImagoCore.Models
{
    public class Spieler
    {
        private readonly IFertigkeitVeraendernService _fertigkeitVeraendernService;

        public Spieler(IFertigkeitVeraendernService fertigkeitVeraendernService)
        {
            _fertigkeitVeraendernService = fertigkeitVeraendernService;

            Modifikationen = new List<Modifikation>();

            Attribute = new AttributeCollection();
            Attribute.FaktischerWertChanged += HandleFaktischerWertAttributChanged;
            FertigkeitsKategorien = new FertigkeitsKategorieCollection();
            Koerper = new KoerperTeileCollection();
            ConstructAbhaengigkeiten();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ImagoRasse Rasse { get; set; }
        public string Notiz { get; set; }
        public AttributeCollection Attribute { get; set; }
        public FertigkeitsKategorieCollection FertigkeitsKategorien { get; set; }
        public KoerperTeileCollection Koerper { get; set; }
        public BeprobbareFertigkeit Initiative { get; set; }
        public BeprobbareFertigkeit EgoRegeneration { get; set; }
        public BeprobbareFertigkeit SchadensMod { get; set; }
        public BeprobbareFertigkeit Lastgrenze { get; set; }
        public List<Modifikation> Modifikationen { get; set; }

        public void AddModifikation(Modifikation mod)
        {
            Modifikationen.Add(mod);
        }

        public void GibErfahrungAnAttribut(ImagoAttribut attribut)
        {
            var attributObject = Attribute.FirstOrDefault(attr => attr.Identifier.Equals(attribut));
            attributObject.Erfahrung++;
        }

        public void HandleFaktischerWertAttributChanged(object sender, FaktischerWertChangedEventArgs args)
        {
            var collection = (AttributeCollection)sender;

            if (collection == null)
            {
                throw new ArgumentException("Der Sender ist keine AttributCollection oder null");
            }

            if (args == null)
            {
                throw new ArgumentException("Das sendende Attribut konnte nicht erkannt werden: args == null");
            }

            ImagoAttribut attribut = (ImagoAttribut)args.Entitaet.Identifier;
            if (attribut == null)
            {
                throw new ArgumentException("Das sendende Attribut konnte nicht erkannt werden: Casting-Fehler");
            }

#if debug
            Console.WriteLine("Event "+ this.GetType().Name+". Der faktische Wert von " + attribut.Name + " wurde geändert.")
#endif

            var values = Attribute.GetFaktischeWerte();
            foreach (var item in FertigkeitsKategorien)
            {
                var attributReferenzen = new List<ImagoAttribut>(item.AttributReferenzen);

                if (attributReferenzen.Contains(attribut))
                {
                    item.BerechneNatuerlicherWert(values);
                }
            }

            Initiative.BerechneNatuerlicherWert(values);
            SchadensMod.BerechneNatuerlicherWert(values);
            EgoRegeneration.BerechneNatuerlicherWert(values);
            Lastgrenze.BerechneNatuerlicherWert(values);

            if (attribut == ImagoAttribut.Konstitution)
            {
                foreach (var teil in Koerper)
                {
                    teil.BerechneTrefferpunkte(values[ImagoAttribut.Konstitution]);
                }
            }
        }

        private void ConstructAbhaengigkeiten()
        {
            Initiative = new BeprobbareFertigkeit(GetNewEntitaet(ImagoNichtSteigerbareFertigkeit.Initiative), new InitiativeNatuerlicherWertBerechnenStrategy());
            SchadensMod = new BeprobbareFertigkeit(GetNewEntitaet(ImagoNichtSteigerbareFertigkeit.SchadensModifikator), new SchadensModifikationNatuerlicherWertBerechnenStrategy());
            EgoRegeneration = new BeprobbareFertigkeit(GetNewEntitaet(ImagoNichtSteigerbareFertigkeit.EgoRegeneration), new EgoRegenerationNatuerlicherWertBerechnenStrategy());
            Lastgrenze = new BeprobbareFertigkeit(GetNewEntitaet(ImagoNichtSteigerbareFertigkeit.LastGrenze), new LastgrenzeBerechnenStrategy());
        }


        public void SteigereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit)
        {
            var oldValue = fertigkeit.SteigerungsWert;
            _fertigkeitVeraendernService.SteigereFertigkeit(ref fertigkeit);
            
            //uebertragen der ep auf die attribute. noch nicht umgesetzt, da der anwender dafuer ein attribut auswaehlen muss.
            //optionen: event und vermerken der moeglichen steigerungen in attributecollection
            if (fertigkeit is FertigkeitsKategorie)
            { }
            //uebertragen der ep auf die kategorie, bei steigern einer fertigkeit
            if ( fertigkeit is Fertigkeit)
            {
                if (fertigkeit.SteigerungsWert != oldValue)
                {
                    var parent = FertigkeitsKategorien.GetParent((Fertigkeit)fertigkeit);
                    parent.Erfahrung++;
                }
            }
        }

        public void ReduziereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit)
        {
            if (fertigkeit is Attribut)
            {
                _fertigkeitVeraendernService.ReduziereFertigkeit(ref fertigkeit);
            }
            if (fertigkeit is FertigkeitsKategorie)
            {
                //kategorie reduzieren nur moeglich, wenn ein passendes attribut ep hat                
                //mMn nicht umsetzen
            }
            if (fertigkeit is Fertigkeit)
            {
                //fertigkeit reduzieren nur moeglich, wenn kategorie mind 1 ep hat

                var parent = FertigkeitsKategorien.GetParent((Fertigkeit)fertigkeit);
                if (parent.Erfahrung > 0)
                {
                    parent.Erfahrung--;
                    _fertigkeitVeraendernService.ReduziereFertigkeit(ref fertigkeit);
                }

            }

        }

    }


}