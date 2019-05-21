using ImagoCore.Enums;
using ImagoCore.Models.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static ImagoCore.Models.ImagoEntitaetFactory;

namespace ImagoCore.Models
{
    public class AttributeCollection : ICollection<Attribut>, INotifyFaktischerWertChanged
    {
        public Attribut Staerke { get; set; }
        public Attribut Geschicklichkeit { get; set; }
        public Attribut Konstitution { get; set; }
        public Attribut Intelligenz { get; set; }
        public Attribut Willenskraft { get; set; }
        public Attribut Charisma { get; set; }
        public Attribut Wahrnehmung { get; set; }        

        public AttributeCollection()
        {
            Staerke = new Attribut(GetNewEntitaet(ImagoAttribut.Staerke));
            Staerke.FaktischerWertChanged += OnFaktischerWertChanged;

            Geschicklichkeit = new Attribut(GetNewEntitaet(ImagoAttribut.Geschicklichkeit));
            Geschicklichkeit.FaktischerWertChanged += OnFaktischerWertChanged;

            Konstitution = new Attribut(GetNewEntitaet(ImagoAttribut.Konstitution));
            Konstitution.FaktischerWertChanged += OnFaktischerWertChanged;

            Intelligenz = new Attribut(GetNewEntitaet(ImagoAttribut.Intelligenz));
            Intelligenz.FaktischerWertChanged += OnFaktischerWertChanged;

            Willenskraft = new Attribut(GetNewEntitaet(ImagoAttribut.Willenskraft));
            Willenskraft.FaktischerWertChanged += OnFaktischerWertChanged;

            Charisma = new Attribut(GetNewEntitaet(ImagoAttribut.Charisma));
            Charisma.FaktischerWertChanged += OnFaktischerWertChanged;

            Wahrnehmung = new Attribut(GetNewEntitaet(ImagoAttribut.Wahrnehmung));
            Wahrnehmung.FaktischerWertChanged += OnFaktischerWertChanged;
        }

        public Dictionary<ImagoAttribut, int> GetFaktischeWerte()
        {
            Dictionary<ImagoAttribut, int> result = new Dictionary<ImagoAttribut, int>();
            foreach (var item in this)
            {
                result.Add((ImagoAttribut)item.Identifier.Identifier, item.FaktischerWert);
            }
            return result;
        }

        #region IEnumerable<T>
        public IEnumerator<Attribut> GetEnumerator()
        {
            yield return Staerke;
            yield return Geschicklichkeit;
            yield return Konstitution;
            yield return Intelligenz;
            yield return Willenskraft;
            yield return Charisma;
            yield return Wahrnehmung;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region ICollection<T>       
        public int Count => 7;

        public bool IsReadOnly => true;

        public void Add( Attribut item )
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains( Attribut item )
        {
            throw new NotSupportedException();
        }

        public void CopyTo( Attribut[] array, int arrayIndex )
        {
            throw new NotSupportedException();
        }

        public bool Remove( Attribut item )
        {
            throw new NotSupportedException();
        }
        #endregion        

        #region INFWC
        public event EventHandler<FaktischerWertChangedEventArgs> FaktischerWertChanged;
        public virtual void OnFaktischerWertChanged(object sender, FaktischerWertChangedEventArgs args)
        {
            FaktischerWertChanged?.Invoke(this, args);
        }        
        #endregion
    }
}
