using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class ApoioViewModel : ListViewModelBase<ApoioWrapper>
    {
        readonly IApoioService _apoioService;

        public ApoioViewModel(IApoioService apoioService) : base(Resource.ApoioTitle)
        {
            _apoioService = apoioService;
            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                await InitializeAsync();
            });
        }

        protected override async Task<IEnumerable<ApoioWrapper>> GetItemsAsync()
            => await _apoioService.GetApoioAsync();
    }
}
