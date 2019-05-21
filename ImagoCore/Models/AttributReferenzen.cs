using ImagoCore.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagoCore.Models
{
    public class AttributReferenzen : ICollection<ImagoAttribut>
    {
        private readonly ImagoAttribut[] _attribute;

        public AttributReferenzen( ImagoAttribut[] attribute)
        {
            _attribute = attribute;
        }

        public override string ToString()
        {
            return string.Join( "+", _attribute.Select( attr => attr.Abbreviation) );            
        }

        // override object.Equals
        public override bool Equals( object obj )
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if ( obj == null || GetType() != obj.GetType() )
            {
                return false;
            }

            return _attribute.SequenceEqual((ImagoAttribut[])obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _attribute.GetHashCode();
        }

        #region ICollection<T>
        public int Count => 4;

        public bool IsReadOnly => true;

        public void Add( ImagoAttribut item )
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains( ImagoAttribut item )
        {
            return _attribute.Contains( item );            
        }

        public void CopyTo( ImagoAttribut[] array, int arrayIndex )
        {
            throw new NotSupportedException();
        }

        public bool Remove( ImagoAttribut item )
        {
            throw new NotSupportedException();
        }
#endregion

        #region IEnumerable<T>
        public IEnumerator<ImagoAttribut> GetEnumerator()
        {
            yield return _attribute[0];
            yield return _attribute[1];
            yield return _attribute[2];
            yield return _attribute[3];            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
