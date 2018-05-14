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
            var uri = new Uri(obj.MapaDirect);
            Device.OpenUri(uri);
        }
        protected async override Task<InformacaoWrapper> GetItemAsync()
            => _infoService.GetItem();

        protected override void OnLoadedData()
        {
            base.OnLoadedData();

            Items.Clear();
            Item.Notas.ToList().ForEach(n => Items.Add(
                            new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Nota }));
            Items.Add(new SummitInfoWrapper {
                                Tipo = SummitInfoType.Endereco,
                                Dados = new EnderecoWrapper {
                                            Lat = Item.Lat, Local = Item.Local, Lon = Item.Lon } });
            Item.Organizacao.ToList().ForEach(n 
                    => Items.Add(new SummitInfoWrapper { Dados = n, Tipo = SummitInfoType.Organizacao }));
        }
    }
}
