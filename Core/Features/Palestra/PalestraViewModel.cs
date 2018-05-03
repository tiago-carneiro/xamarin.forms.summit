using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class PalestraViewModel : ItemViewModelBase<PalestraWrapper>
    {
        readonly IPalestraService _palestraService;
        string _id;

        public ICommand ItemClickCommand { get; }

        public PalestraViewModel(IPalestraService palestraService) : base(Resource.PalestraTitle, true)
        {
            _palestraService = palestraService;
            ItemClickCommand = new Command<PalestranteWrapper>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        protected override async Task<PalestraWrapper> GetItemAsync()
            => await _palestraService.GetPalestraAsync(_id);

        public override async Task InitializeAsync(object parameter)
        {
            var palestraParameter = parameter as PalestraParameter;
            _id = palestraParameter.Id;
            await base.InitializeAsync();
        }

        protected override void OnLoadedData()
        {
            base.OnLoadedData();
            var lista = Item.Palestrantes;
        }

        async Task ItemClickCommandExecuteAsync(PalestranteWrapper item)
        {

        }
    }
}
