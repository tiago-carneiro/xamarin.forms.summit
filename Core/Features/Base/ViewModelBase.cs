using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public abstract class ViewModelBase : NotifyPropertyChanged
    {
        bool _canHandle = false;
        bool _mainLoaded = false;

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

        private bool _dataLoaded;
        public bool DataLoaded
        {
            get => _dataLoaded;
            set => SetProperty(ref _dataLoaded, value);
        }

        private bool _showMessage;
        public bool ShowMessage
        {
            get => _showMessage;
            set => SetProperty(ref _showMessage, value);
        }

        protected ViewModelBase(string title, bool implementLoadInfoHandle = false)
        {
            Title = title;
            Message = Resource.LoadingMessage;
            if (implementLoadInfoHandle)
                MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData,
                    async (sender, args) => await LoadInfoHandleAsync(args));

        }

        public virtual async Task InitializeAsync()
            => _canHandle = true;

        public virtual async Task InitializeAsync(object parameter)
            => _canHandle = true;

        async Task LoadInfoHandleAsync(LoadInfoResult info)
        {
            _mainLoaded = true;
            if (!_canHandle)
                return;

            switch (info.Status)
            {
                case LoadInfoStatus.None:
                    ValidateLoad();
                    break;
                case LoadInfoStatus.Updated:
                    await InitializeAsync();
                    break;
                case LoadInfoStatus.Error:
                    if (!DataLoaded)
                        Message = info.Message;
                    break;
            }
        }

        protected virtual void ValidateLoad() { }

        protected virtual void EmptyLoad()
        {
            if (_mainLoaded)
                Message = Resource.EmptyLoadMessage;
        }

        protected virtual void OnLoadedData()
        {
            Message = "";
            DataLoaded = true;
        }
    }
}
