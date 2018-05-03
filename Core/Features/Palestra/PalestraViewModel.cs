using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class PalestraViewModel : ItemViewModelBase<PalestraWrapper>
    {
        readonly IPalestraService _palestraService;
        string _id;

        public PalestraViewModel(IPalestraService palestraService) : base(Resource.PalestraTitle, true)
            => _palestraService = palestraService;

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
    }
}
