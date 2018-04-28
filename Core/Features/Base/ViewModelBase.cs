using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                SetProperty(ref _message, value);
                ShowMessage = !string.IsNullOrEmpty(_message);
            }
        }

        private bool _showMessage;
        public bool ShowMessage
        {
            get => _showMessage;
            set => SetProperty(ref _showMessage, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] string propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected ViewModelBase(string title, bool implementLoadInfoHandle = false)
        {
            Title = title;
            if(implementLoadInfoHandle)
                MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData,
                    async (sender, args) => await LoadInfoHandleAsync(args));
        }

        public virtual async Task InitializeAsync()
            => await Task.FromResult(true);

        public virtual async Task InitializeAsync(object parameter)
            => await Task.FromResult(true);

        async Task LoadInfoHandleAsync(LoadInfoResult info)
        {
            switch (info.Status)
            {
                case LoadInfoStatus.None:
                    break;
                case LoadInfoStatus.Updated:
                    await InitializeAsync();
                    break;
                case LoadInfoStatus.Error:
                    Message = info.Message;
                    break;
            }
        }
    }
}
