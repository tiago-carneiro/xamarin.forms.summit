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

        protected ItemViewModelBase(string title) : base(title)
        {
        }

        protected abstract Task<TModel> GetItemAsync();

        public override async Task InitializeAsync()
            => Item = await GetItemAsync();
    }
}
