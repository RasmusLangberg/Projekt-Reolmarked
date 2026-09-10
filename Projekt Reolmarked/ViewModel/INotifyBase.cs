using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class INotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
