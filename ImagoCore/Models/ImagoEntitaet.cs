using ImagoCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models
{
    public class ImagoEntitaet
    {
        public SpielerBereich Bereich{ get;  }
        public Enumeration Identifier { get;  }

        public ImagoEntitaet(SpielerBereich bereich, Enumeration identifier)
        {
            Bereich = bereich;
            Identifier = identifier;
        }
        public ImagoEntitaet()
        {

        }
        public override string ToString()
        {
            return Identifier.DisplayName;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (!((ImagoEntitaet)obj).Bereich.Equals(Bereich))
                return false;

            return Identifier.Equals( ( ( ImagoEntitaet ) obj ).Identifier );
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Bereich.GetHashCode() + Identifier.GetHashCode();
        }
    }
}
