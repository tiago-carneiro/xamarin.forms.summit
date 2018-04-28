using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public abstract class TabbedItemViewModel : ViewModelBase
    {
        bool _hasInitialized;

        protected TabbedItemViewModel(string title) : base(title)
        { }

        public override async Task InitializeAsync()
        {
            if (_hasInitialized)
                return;
            _hasInitialized = true;
            await base.InitializeAsync();           
        }
    }
}
