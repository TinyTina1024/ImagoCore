using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Models.Events
{
    public interface INotifyAttributChanged
    {
        event EventHandler<AttributChangedEventArgs> AttributChanged;
    }
}
