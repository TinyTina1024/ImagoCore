namespace ImagoCore.Models
{
    public abstract class SteigerbareFertigkeitBase : BeprobbareFertigkeitBase
    {
        protected int _erfahrung;
        protected int _steigerungsWert;
        //dieser ctor ist wegen der vererbung notwendig
        public SteigerbareFertigkeitBase(ImagoEntitaet identifier) : base(identifier) { }
        
        public SteigerbareFertigkeitBase() { }

        public virtual int SteigerungsWert { get { return _steigerungsWert; } set { _steigerungsWert = value; OnPropertyChanged(); OnPropertyChanged(nameof(FaktischerWert)); } }
        public int Erfahrung { get => _erfahrung; set { _erfahrung = value; OnPropertyChanged(); } }
        public override int FaktischerWert => NatuerlicherWert + Modifikation + SteigerungsWert;
        
    }
}
