using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class PalestraViewModel : ItemViewModelBase<PalestraWrapper>
    {
        readonly IPalestraService _palestraService;
        readonly INavigationService _navigationService;
        string _id;

        public ICommand ItemClickCommand { get; }

        public PalestraViewModel(IPalestraService palestraService, INavigationService navigationService)
            : base(Resource.PalestraTitle, true)
        {
            _palestraService = palestraService;
            _navigationService = navigationService;
            ItemClickCommand = new Command<PalestranteWrapper>(async (item)
                                => await ItemClickCommandExecuteAsync(item));
        }

        protected override async Task<PalestraWrapper> GetItemAsync()
            => _palestraService.GetPalestra(_id);

        public override async Task InitializeAsync(object parameter)
        {
            _id = (parameter as PalestraParameter).Id;
            await base.InitializeAsync();
        }

        async Task ItemClickCommandExecuteAsync(PalestranteWrapper item)
        {
            if (!string.IsNullOrEmpty(item.Link))
                Device.OpenUri(new Uri(item.Link));
        }
    }
}
