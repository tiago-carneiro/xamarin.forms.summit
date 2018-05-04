using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xamarin.Summit
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] string propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
