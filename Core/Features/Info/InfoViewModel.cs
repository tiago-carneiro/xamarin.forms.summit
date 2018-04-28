using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class InfoViewModel : ItemViewModelBase<InformacaoWrapper>
    {
        readonly IInfoService _infoService;
        
        public InfoViewModel(IInfoService infoService) : base(Resource.InfoTitle)
        {
            _infoService = infoService;

            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                if (args.Success)
                    await InitializeAsync();
            });
        }

        protected async override Task<InformacaoWrapper> GetItemAsync()
            => await _infoService.GetItemAsync();
    }
}
