using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nework.CommonLibrary
{
    public class PropertyChangeSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
