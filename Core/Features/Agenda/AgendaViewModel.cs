using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public class AgendaViewModel : ListViewModelBase<AgendaWrapper>
    {
        readonly IAgendaService _agendaService;

        public AgendaViewModel(IAgendaService agendaService) : base(Resource.AgendaTitle, true)
            => _agendaService = agendaService;

        protected override async Task<IEnumerable<AgendaWrapper>> GetItemsAsync()
            => await _agendaService.GetAgendaAsync();

        protected override void OnLoadedItems()
            => Message = Items?.FirstOrDefault()?.Descricao ?? "Carregando";
    }
}
