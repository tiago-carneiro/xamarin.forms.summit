using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class ApoioViewModel : ListViewModelBase<ApoioWrapper>
    {
        readonly IApoioService _apoioService;

        public ApoioViewModel(IApoioService apoioService) : base(Resource.ApoioTitle, true)
            => _apoioService = apoioService;

        protected override async Task<IEnumerable<ApoioWrapper>> GetItemsAsync()
            => await _apoioService.GetApoioAsync();
    }
}
