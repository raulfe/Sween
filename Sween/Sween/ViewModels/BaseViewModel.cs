using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sween.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingfield, T value, [CallerMemberName] string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingfield, value))
            {
                return;
            }
            backingfield = value;
            OnPropertyChanged(propertyName);
        }
    }
}
