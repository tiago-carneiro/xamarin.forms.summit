using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class AgendaViewModel : ListViewModelBase<AgendaWrapper>
    {
        readonly IAgendaService _agendaService;

        public ICommand HeaderClickCommand { get; }

        private AgendaHeaderWrapper _headerOne = new AgendaHeaderWrapper { Titulo = Resource.DayOneTitle };
        public AgendaHeaderWrapper HeaderOne
        {
            get => _headerOne;
            set => SetProperty(ref _headerOne, value);
        }

        private AgendaHeaderWrapper _headerTwo = new AgendaHeaderWrapper { Titulo = Resource.DayTwoTitle };
        public AgendaHeaderWrapper HeaderTwo
        {
            get => _headerTwo;
            set => SetProperty(ref _headerTwo, value);
        }
        
        private AgendaHeaderWrapper _currentHeader;
        public AgendaHeaderWrapper CurrentHeader
        {
            get => _currentHeader;
            set => SetProperty(ref _currentHeader, value);
        }

        public AgendaViewModel(IAgendaService agendaService) : base(Resource.AgendaTitle, true)
        {
            _agendaService = agendaService;

            HeaderClickCommand = new Command<AgendaHeaderWrapper>(async (item) => await HeaderClickCommandExecuteAsync(item));
            CurrentHeader = HeaderOne;
        }

        protected override async Task<IEnumerable<AgendaWrapper>> GetItemsAsync()
            => await _agendaService.GetAgendaAsync();

        protected override void OnLoadedItems()
        {
            Message = Items?.FirstOrDefault()?.Descricao ?? Message;
            if (Items.Any())
            {
                HeaderOne = GetAgendaHeader(0);
                HeaderTwo = GetAgendaHeader(1);
            }
        }

        AgendaHeaderWrapper GetAgendaHeader(int index)
            =>  new AgendaHeaderWrapper { Index = 0, Titulo = Items[index].Descricao };

        async Task HeaderClickCommandExecuteAsync(AgendaHeaderWrapper header)
            => CurrentHeader = header;
    }
}
