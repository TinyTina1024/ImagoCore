using System.Collections.Generic;

namespace ImagoCore.Models
{
    public class Modifikation
    {
        public int Effekt { get; set; }
        public string Name { get;  }
        public List<ImagoEntitaet> Ziele { get; set; }
        public ImagoEntitaet Quelle { get;  }
        public bool IstEffektVeraenderbar { get; set; }

        public Modifikation(string name, ImagoEntitaet quelle, bool istEffektVeraenderbar = false )
        {
            Name = name;
            Quelle = quelle;
            IstEffektVeraenderbar = istEffektVeraenderbar;
            Ziele = new List<ImagoEntitaet>();
        }
    }
}
