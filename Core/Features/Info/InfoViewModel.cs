using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class InfoViewModel : ItemViewModelBase<InformacaoWrapper>
    {
        readonly IInfoService _infoService;
        
        public InfoViewModel(IInfoService infoService) : base(Resource.InfoTitle, true)
            => _infoService = infoService;

        protected async override Task<InformacaoWrapper> GetItemAsync()
            => await _infoService.GetItemAsync();

        protected override void OnLoadedItem()
            => Message = Item?.Descricao;
    }
}
