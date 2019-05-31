using ImagoCore.Enums;
using ImagoCore.Models.Strategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImagoCore.Models
{
    public class KoerperTeil : ITrefferpunkteBerechenbar, INotifyPropertyChanged
    {
        private ITrefferpunkteBerechnenStrategy _trefferpunkteBerechnenStrategy;
        private int _currentTrefferpunkte;

        public ImagoEntitaet Identifier { get; }
        public int MaxTrefferPunkte { get; private set; }
        public int CurrentTrefferPunkte { get { return _currentTrefferpunkte; } set { _currentTrefferpunkte = value; OnPropertyChanged(); } }
        public List<KoerperTeilZustand> Zustaende { get; set; }

        public KoerperTeil(ImagoEntitaet identifier, ITrefferpunkteBerechnenStrategy trefferpunkteBerechnenStrategy)
        {
            Identifier = identifier;
            _trefferpunkteBerechnenStrategy = trefferpunkteBerechnenStrategy;
            Zustaende = new List<KoerperTeilZustand>()
            {
                KoerperTeilZustand.Gesund
            };
            CurrentTrefferPunkte = MaxTrefferPunkte;
        }

        public void BerechneTrefferpunkte(int konstitution)
        {
            MaxTrefferPunkte = _trefferpunkteBerechnenStrategy.BerechneTrefferpunkte(konstitution);
            OnPropertyChanged(nameof(MaxTrefferPunkte));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
