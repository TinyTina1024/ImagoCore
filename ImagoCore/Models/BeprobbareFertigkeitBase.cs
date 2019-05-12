using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models
{
    public abstract class BeprobbareFertigkeitBase : FertigkeitBase
    {
        public BeprobbareFertigkeitBase(ImagoEntitaet identifier) :base(identifier){ }
        public BeprobbareFertigkeitBase()
        {

        }
        protected int _modifikation;
        public virtual int FaktischerWert => NatuerlicherWert + Modifikation;
        public virtual int Modifikation { get { return _modifikation; } set { _modifikation = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); } }
    }
}
