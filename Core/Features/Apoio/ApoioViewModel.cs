using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class ApoioViewModel : GroupedListViewModelBase<string, ApoioWrapper>
    {
        readonly IApoioService _apoioService;

        public ApoioViewModel(IApoioService apoioService) : base(Resource.ApoioTitle, true)
            => _apoioService = apoioService;

        protected override async Task<IEnumerable<ApoioWrapper>> GetItemsAsync()
            => _apoioService.GetApoio();

        protected override Func<ApoioWrapper, string> GroupBy()
            => x => x.Categoria;

        protected override async Task ItemClickCommandExecuteAsync(ApoioWrapper model)
            => Device.OpenUri(new Uri(model.Link));
    }
}
