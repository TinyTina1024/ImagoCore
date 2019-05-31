using ImagoCore.Enums;
using ImagoCore.Models.Strategies;
using System.Collections;
using System.Collections.Generic;
using static ImagoCore.Models.ImagoEntitaetFactory;

namespace ImagoCore.Models
{
    public class KoerperTeileCollection : IReadOnlyCollection<KoerperTeil>
    {
        public KoerperTeil Kopf { get;  }
        public KoerperTeil Torso { get;  }
        public KoerperTeil ArmLinks { get;  }
        public KoerperTeil ArmRechts { get;  }
        public KoerperTeil BeinLinks { get;  }
        public KoerperTeil BeinRechts { get;  }

        public int Count => 6;        

        public KoerperTeileCollection()
        {
            Kopf = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.Kopf), new KopfTrefferpunkteBerechnenStrategy());
            Torso = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.Torso), new TorsoTrefferpunkteBerechnenStrategy());
            ArmLinks = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.ArmLinks), new ArmTrefferpunkteBerechnenStrategy());
            ArmRechts = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.ArmRechts), new ArmTrefferpunkteBerechnenStrategy());
            BeinLinks = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.BeinLinks), new BeinTrefferpunkteBerechnenStrategy());
            BeinRechts = new KoerperTeil(GetNewEntitaet(ImagoKoerperTeil.BeinRechts), new BeinTrefferpunkteBerechnenStrategy());
        }

        #region IEnumerable<T>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KoerperTeil> GetEnumerator()
        {
            yield return Kopf;
            yield return Torso;
            yield return ArmLinks;
            yield return ArmRechts;
            yield return BeinLinks;
            yield return BeinRechts;            
        }

        public void Add( KoerperTeil item )
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains( KoerperTeil item )
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo( KoerperTeil[] array, int arrayIndex )
        {
            throw new System.NotImplementedException();
        }

        public bool Remove( KoerperTeil item )
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
