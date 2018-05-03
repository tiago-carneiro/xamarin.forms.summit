using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class AgendaViewModel : ListViewModelBase<AgendaWrapper>
    {
        readonly IAgendaService _agendaService;
        readonly INavigationService _navigationService;

        public ICommand HeaderClickCommand { get; }
        public ICommand TimeLineClickCommand { get; }

        public ObservableCollection<TimeLineWrapper> TimeLine { get; }

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

        public AgendaViewModel(IAgendaService agendaService, INavigationService navigationService) : base(Resource.AgendaTitle, true)
        {
            _agendaService = agendaService;
            _navigationService = navigationService;

            HeaderClickCommand = new Command<AgendaHeaderWrapper>(async (item) => await HeaderClickCommandExecuteAsync(item));
            TimeLineClickCommand = new Command<TimeLineWrapper>(async (item) => await TimeLineClickCommandExecuteAsync(item));

            CurrentHeader = HeaderOne;
            TimeLine = new ObservableCollection<TimeLineWrapper>();
        }

        protected override async Task<IEnumerable<AgendaWrapper>> GetItemsAsync()
            => await _agendaService.GetAgendaAsync();

        protected override void OnLoadedData()
        {
            base.OnLoadedData();

            HeaderOne = GetAgendaHeader(0);
            HeaderTwo = GetAgendaHeader(1);

            LoadTimeLine(CurrentHeader.Index);
        }

        AgendaHeaderWrapper GetAgendaHeader(int index)
            => new AgendaHeaderWrapper { Index = index, Titulo = Items[index].Descricao };

        async Task HeaderClickCommandExecuteAsync(AgendaHeaderWrapper header)
            => SetCurrentItems(header);

        void SetCurrentItems(AgendaHeaderWrapper header)
        {
            if (CurrentHeader == header)
                return;

            CurrentHeader = header;
            LoadTimeLine(CurrentHeader.Index);
        }

        void LoadTimeLine(int index)
        {
            TimeLine.Clear();
            if (Items.Any())
                Items[index].TimeLine.ToList().ForEach(i => TimeLine.Add(i));
        }

        async Task TimeLineClickCommandExecuteAsync(TimeLineWrapper model)
            => await _navigationService.NavigateToAsync<PalestraViewModel>(new PalestraParameter { Id = model.Id });
    }
}
