using System;
using System.Collections.Generic;
using ImagoCore.Enums;
using ImagoCore.Models.Events;
using ImagoCore.Models.Strategies;

namespace ImagoCore.Models
{
    public class FertigkeitsKategorie : SteigerbareFertigkeitBase, INotifyFaktischerWertChanged, INwBerechenbar
    {
        public AttributReferenzen AttributReferenzen { get; private set; }        

        public event EventHandler<FaktischerWertChangedEventArgs> FaktischerWertChanged;        

        public FertigkeitsKategorie(ImagoEntitaet identifier, ImagoAttribut[] attributReferenzen) : base(identifier)
        {            
            AttributReferenzen = new AttributReferenzen( attributReferenzen );
            _kategorieBerechnenStrategy = new FertigkeitsKategorieNatuerlicherWertBerechnenStrategy(attributReferenzen);            
        }
        public FertigkeitsKategorie()
        {

        }

        public List<Fertigkeit> Fertigkeiten { get; set; }
        private INatuerlicherWertBerechnenStrategy _kategorieBerechnenStrategy { get; }       

        public void BerechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            if(_kategorieBerechnenStrategy != null)
                NatuerlicherWert = _kategorieBerechnenStrategy.berechneNatuerlicherWert(values);           
        }

        //alle propertys muessen ueberschrieben werden, damit INPC richtig triggert
        public override int NatuerlicherWert { get { return _natuerlicherWert; } set { _natuerlicherWert = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier));  } }
        public override int Modifikation { get { return _modifikation; } set { _modifikation = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier)); } }
        public override int SteigerungsWert { get { return _steigerungsWert; } set { _steigerungsWert = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier)); } }


        private void OnFaktischerWertChanged(FaktischerWertChangedEventArgs faktischerWertChangedEventArgs)
        {
            if (Fertigkeiten != null)
                foreach (var item in Fertigkeiten)
                {
                    item.NatuerlicherWert = this.FaktischerWert;
                }

            FaktischerWertChanged?.Invoke(this, faktischerWertChangedEventArgs);
        }

        
    }
}
