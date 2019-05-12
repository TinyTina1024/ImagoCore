using ImagoCore.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models
{
    public class Attribut : SteigerbareFertigkeitBase, INotifyFaktischerWertChanged
    {
        private int _korrosion;        

        public Attribut(ImagoEntitaet identifier) : base(identifier)        {
                 
        }

        public Attribut()
        {
                
        }
        //alle propertys muessen ueberschrieben werden, damit INPC richtig triggert
        public override int SteigerungsWert { get { return _steigerungsWert; } set { _steigerungsWert = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier)); } }
        public override int NatuerlicherWert { get { return _natuerlicherWert; } set { _natuerlicherWert = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier)); } }
        public override int Modifikation { get { return _modifikation; } set { _modifikation = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier)); } }
        public virtual int Korrosion { get { return _korrosion; } set { _korrosion = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); OnFaktischerWertChanged(new FaktischerWertChangedEventArgs(Identifier));  } }
        public override int FaktischerWert => NatuerlicherWert + SteigerungsWert - Korrosion + Modifikation;         

        #region INFWC
        public event EventHandler<FaktischerWertChangedEventArgs> FaktischerWertChanged;
        public virtual void OnFaktischerWertChanged(FaktischerWertChangedEventArgs args)
        {
            FaktischerWertChanged?.Invoke(this, args);
        }
        #endregion

        
    }

}
