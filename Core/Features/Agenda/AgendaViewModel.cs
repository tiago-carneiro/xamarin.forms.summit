using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class AgendaViewModel : ListViewModelBase<AgendaWrapper>
    {
        readonly IAgendaService _agendaService;

        public AgendaViewModel(IAgendaService agendaService) : base(Resource.AgendaTitle)
        {
            _agendaService = agendaService;
            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                await InitializeAsync();
            });
        }

        protected override async Task<IEnumerable<AgendaWrapper>> GetItemsAsync()
            => await _agendaService.GetAgenda();
    }
}
