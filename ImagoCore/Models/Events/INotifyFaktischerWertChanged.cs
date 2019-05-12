using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Events
{
    //
    // Summary:
    //     Notifies clients that a faktischer Wert has changed.
    public interface INotifyFaktischerWertChanged
    {
        //
        // Summary:
        //     Occurs when a faktischer Wert changes.
        event EventHandler<FaktischerWertChangedEventArgs> FaktischerWertChanged;
    }
}
