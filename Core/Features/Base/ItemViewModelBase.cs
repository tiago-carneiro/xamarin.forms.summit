using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public abstract class ItemViewModelBase<TModel> : ViewModelBase
    {
        private TModel _item;
        public TModel Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        protected ItemViewModelBase(string title, bool implementLoadInfoHandle = false) : base(title, implementLoadInfoHandle)
        {
        }

        protected abstract Task<TModel> GetItemAsync();

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            Item = await GetItemAsync();
            ValidateLoad();
        }

        protected override void ValidateLoad()
        {
            if (Item != null)
                OnLoadedData();
            else
                EmptyLoad();
        }
    }
}
