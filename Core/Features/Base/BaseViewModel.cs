﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] string propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public BaseViewModel(string title) 
            => Title = title;

        public async Task InitializeAsync()
            => await Task.FromResult(true);

        public async Task InitializeAsync(object parameter)
            => await Task.FromResult(true);
    }
}
