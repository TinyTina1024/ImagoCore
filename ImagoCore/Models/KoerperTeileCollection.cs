using ImagoCore.Enums;
using ImagoCore.Models.Strategies;
using System.Collections;
using System.Collections.Generic;
using static ImagoCore.Models.ImagoEntitaetFactory;

namespace ImagoCore.Models
{
    public class KoerperTeileCollection : ICollection<KoerperTeil>
    {
        public KoerperTeil Kopf { get; set; }
        public KoerperTeil Torso { get; set; }
        public KoerperTeil ArmLinks { get; set; }
        public KoerperTeil ArmRechts { get; set; }
        public KoerperTeil BeinLinks { get; set; }
        public KoerperTeil BeinRechts { get; set; }

        public int Count => 6;

        public bool IsReadOnly => true;

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
