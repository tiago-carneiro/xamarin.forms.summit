using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class MainViewModel : ViewModelBase
    {
        readonly ISummitInfoService _summitInfoService;
        readonly IInternetConnectionService _interntConnectionService;

        public MainViewModel(ISummitInfoService summitInfoService, IInternetConnectionService interntConnectionService) : base(Resource.MainTitle)
        {
            _summitInfoService = summitInfoService;
            _interntConnectionService = interntConnectionService;
        }

        public override async Task InitializeAsync()
        {
            LoadInfoResult result = new LoadInfoResult(LoadInfoStatus.None);
            if (_interntConnectionService.IsConnected)
                result = await _summitInfoService.LoadInformacoesAsync();
            MessagingCenter.Send(this, ConstantHelper.ReloadData, result);
        }
    }
}
