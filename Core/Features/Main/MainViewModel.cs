using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class MainViewModel : ViewModelBase
    {
        readonly ISummitInfoService _summitInfoService;

        public MainViewModel(ISummitInfoService summitInfoService) : base(Resource.MainTitle)
        {
            _summitInfoService = summitInfoService;
        }

        public override async Task InitializeAsync()
        {
            var result = await _summitInfoService.LoadInformacoesAsync();
            MessagingCenter.Send(this, ConstantHelper.ReloadData, result);
        }
    }
}
