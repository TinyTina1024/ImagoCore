using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Events
{
    public class AttributChangedEventArgs : EventArgs
    {
        public AttributChangedEventArgs(Attribut attributChanged)
        {
            AttributChanged = attributChanged;
        }
        public AttributChangedEventArgs()
        {

        }
        public Attribut AttributChanged { get; }

    }
}
