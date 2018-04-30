using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public abstract class ListViewModelBase<TModel> : ListViewModelBase<TModel, TModel> where TModel : class
    {
        protected ListViewModelBase(string title, bool implementLoadInfoHandle = false) : base(title, implementLoadInfoHandle)
        {
        }

        protected override void AddItems(IEnumerable<TModel> items)
            => items?.ToList()?.ForEach(item => Items.Add(item));
    }

    public abstract class ListViewModelBase<TList, TModel> : ViewModelBase where TModel : class
    {
        public ObservableCollection<TList> Items { get; }

        public ICommand ItemClickCommand { get; }

        protected ListViewModelBase(string title, bool implementLoadInfoHandle = false) : base(title, implementLoadInfoHandle)
        {
            Items = new ObservableCollection<TList>();
            ItemClickCommand = new Command<TModel>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        protected abstract Task<IEnumerable<TModel>> GetItemsAsync();

        protected virtual async Task ItemClickCommandExecuteAsync(TModel model)
            => await Task.FromResult(true);

        public override async Task InitializeAsync()
        {
            var result = await GetItemsAsync();
            Items.Clear();
            AddItems(result);
            OnLoadedItems();
            Message = "";
        }

        protected abstract void AddItems(IEnumerable<TModel> items);

        protected virtual void OnLoadedItems() { }
    }
}
