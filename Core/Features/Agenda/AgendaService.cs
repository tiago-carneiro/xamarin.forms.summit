using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaWrapper>> GetAgendaAsync();
    }

    public class AgendaService : ServiceBase, IAgendaService
    {
        public async Task<IEnumerable<AgendaWrapper>> GetAgendaAsync()
            => await Task.Run(() =>
               {
                   using (var realm = GetRealmInstance())
                   {
                       var agendas = realm.All<Agenda>().ToList();
                       var result = new List<AgendaWrapper>();
                       foreach (var item in agendas)
                       {
                           var agendaWrapper = item.ConvertTo<AgendaWrapper>();
                           agendaWrapper.TimeLine = item.TimeLine.Select(s => s.ConvertTo<TimeLineWrapper>());
                           result.Add(agendaWrapper);
                       }

                       return result;
                   }
               });
    }
}

