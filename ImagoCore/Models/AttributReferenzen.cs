using ImagoCore.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagoCore.Models
{
    public class AttributReferenzen : IReadOnlyCollection<ImagoAttribut>
    {
        private readonly ImagoAttribut[] _attribute;

        public AttributReferenzen( ImagoAttribut[] attribute )
        {
            _attribute = attribute;
        }

        public int Count => 4;

        public override string ToString()
        {
            return string.Join( "+", _attribute.Select( attr => attr.Abbreviation) );            
        }

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
    }
}
