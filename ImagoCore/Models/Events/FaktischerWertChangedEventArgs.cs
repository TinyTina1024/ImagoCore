﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Events
{
    public class FaktischerWertChangedEventArgs : EventArgs
    {
        public FaktischerWertChangedEventArgs(ImagoEntitaet e)
        {
            Entitaet = e;
        }

        public FaktischerWertChangedEventArgs()
        {

        }
        
        public ImagoEntitaet Entitaet { get; set; }
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
            
            return Entitaet.Equals(((FaktischerWertChangedEventArgs)obj).Entitaet);            
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {            
            return Entitaet.GetHashCode();            
        }
    }
}
