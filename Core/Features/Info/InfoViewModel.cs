using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class InfoViewModel : ItemViewModelBase<InformacaoWrapper>
    {
        readonly IInfoService _infoService;

        public ObservableCollection<SummitInfoWrapper> Items { get; }

        public InfoViewModel(IInfoService infoService) : base(Resource.InfoTitle, true)
        {
            _infoService = infoService;
            Items = new ObservableCollection<SummitInfoWrapper>();
        }
        protected async override Task<InformacaoWrapper> GetItemAsync()
            => await _infoService.GetItemAsync();

        protected override void OnLoadedData()
        {
            base.OnLoadedData();

            Items.Clear();
            Item.Notas.ToList().ForEach(n => Items.Add(new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Nota }));
            Items.Add(new SummitInfoWrapper { Tipo = SummitInfoType.Endereco, Dados = new EnderecoWrapper { Lat = Item.Lat, Local = Item.Local, Lon = Item.Lon } });
            Item.Organizacao.ToList().ForEach(n => Items.Add(new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Organizacao }));
        }
    }
}
