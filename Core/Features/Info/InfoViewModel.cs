using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class InfoViewModel : ViewModelBase
    {
        readonly IInfoService _infoService;

        private string _message = "Calma, está carregando";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool Show => !string.IsNullOrEmpty(Message);

        private InformacaoWrapper _informacao;
        public InformacaoWrapper Informacao
        {
            get => _informacao;
            set => SetProperty(ref _informacao, value);
        }

        public InfoViewModel(IInfoService infoService) : base(Resource.InfoTitle)
        {
            _infoService = infoService;

            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                if (args.Success)
                    await InitializeAsync();
                Message = args.Message;
                RaisePropertyChanged(nameof(Show));
            });
        }

        public async override Task InitializeAsync()
        {
            Informacao = _infoService.GetInformacao();
        }
    }
}
