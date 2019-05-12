using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Events
{
    public interface INotifyNatuerlicherWertChanged
    {
        //
        // Summary:
        //     Occurs when a natuerlicher Wert changes.
        event EventHandler<NatuerlicherWertChangedEventArgs> NatuerlicherWertChanged;
    }
}
