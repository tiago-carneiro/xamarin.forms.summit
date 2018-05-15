using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class InfoViewModel : ItemViewModelBase<InformacaoWrapper>
    {
        readonly IInfoService _infoService;


        public ICommand OpenMapCommand { get; }

        public ObservableCollection<SummitInfoWrapper> Items { get; }

        public InfoViewModel(IInfoService infoService) : base(Resource.InfoTitle, true)
        {
            _infoService = infoService;

            OpenMapCommand = new Command<EnderecoWrapper>(ExecuteOpenMapCommand);

            Items = new ObservableCollection<SummitInfoWrapper>();
        }

        private void ExecuteOpenMapCommand(EnderecoWrapper obj)
        {
            var url = "";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    url = $"http://maps.apple.com/?ll={obj.Lat},{obj.Lon}";
                    break;
                case Device.Android:
                    url = $"geo:0,0?q={obj.Lat},{obj.Lon}";
                    break;
                default:
                    throw new NotSupportedException("Not Supported Device Runtime Platform");
            }

            Device.OpenUri(new Uri(url.Trim()));

        }

        protected async override Task<InformacaoWrapper> GetItemAsync()
            => _infoService.GetItem();

        protected override void OnLoadedData()
        {
            base.OnLoadedData();

            Items.Clear();
            Item.Notas.ToList().ForEach(n => Items.Add(
                            new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Nota }));
            Items.Add(new SummitInfoWrapper
            {
                Tipo = SummitInfoType.Endereco,
                Dados = new EnderecoWrapper
                {
                    Lat = Item.Lat,
                    Local = Item.Local,
                    Lon = Item.Lon
                }
            });
            Item.Organizacao.ToList().ForEach(n
                    => Items.Add(new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Organizacao }));
        }
    }
}
