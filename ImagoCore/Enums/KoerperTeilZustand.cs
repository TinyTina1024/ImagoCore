 
namespace ImagoCore.Enums
{
    public class KoerperTeilZustand : Enumeration
    {
        public static readonly KoerperTeilZustand Gesund = new KoerperTeilZustand(0, "Gesund");
        public static readonly KoerperTeilZustand Ausgefallen = new KoerperTeilZustand(1,"Ausgefallen");
        public static readonly KoerperTeilZustand Zerstoert = new KoerperTeilZustand(2, "Zerstört");
        public static readonly KoerperTeilZustand Behandelt = new KoerperTeilZustand(3, "Behandelt");

        public KoerperTeilZustand()
        {

        }
        public KoerperTeilZustand(int value, string displayName) : base(value, displayName)
        {

        }
    }
}
