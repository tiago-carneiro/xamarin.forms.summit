using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public abstract class ListViewModelBase<TModel> : ViewModelBase where TModel : class
    {
        public ObservableCollection<TModel> Items { get; }

        public ICommand ItemClickCommand { get; }

        protected ListViewModelBase(string title, bool implementLoadInfoHandle = false) : base(title, implementLoadInfoHandle)
        {
            Items = new ObservableCollection<TModel>();
            ItemClickCommand = new Command<TModel>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        protected abstract Task<IEnumerable<TModel>> GetItemsAsync();

        protected virtual async Task ItemClickCommandExecuteAsync(TModel model)
            => await Task.FromResult(true);

        public override async Task InitializeAsync()
        {
            var result = await GetItemsAsync();
            Items.Clear();
            result?.ToList()?.ForEach(item => Items.Add(item));
            OnLoadedItems();
            Message = "";
        }

        protected virtual void OnLoadedItems() { }
    }
}
