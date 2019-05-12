using System;
using System.Collections.Generic;
using System.Text;
using ImagoCore.Enums;
using ImagoCore.Models.Strategies;

namespace ImagoCore.Models
{
    public class BeprobbareFertigkeit : BeprobbareFertigkeitBase, INwBerechenbar
    {
        public BeprobbareFertigkeit(ImagoEntitaet identifier, INatuerlicherWertBerechnenStrategy strategy) : base(identifier)
        {
            _natuerlicherWertBerechnenStrategy = strategy;
        }

        public BeprobbareFertigkeit()
        {

        }

        private INatuerlicherWertBerechnenStrategy _natuerlicherWertBerechnenStrategy { get; }

        public void BerechneNatuerlicherWert(Dictionary<ImagoAttribut, int> values)
        {
            if (_natuerlicherWertBerechnenStrategy != null)
                NatuerlicherWert = _natuerlicherWertBerechnenStrategy.berechneNatuerlicherWert(values);
        }
    }
}
