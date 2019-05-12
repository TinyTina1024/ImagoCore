using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ImagoCore.Models
{
    public abstract class FertigkeitBase : INotifyPropertyChanged
    {
        protected int _natuerlicherWert;        
          

        public FertigkeitBase(){}
        

        public FertigkeitBase(ImagoEntitaet identifier)
        {
            Identifier = identifier;
        }

        public virtual ImagoEntitaet Identifier { get; }

        
        public virtual int NatuerlicherWert { get { return _natuerlicherWert; } set { _natuerlicherWert = value; OnPropertyChanged(); } }
        

        public override string ToString()
        {
            return Identifier.ToString();
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

            return Identifier.Equals(((FertigkeitBase)obj).Identifier);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
       
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
