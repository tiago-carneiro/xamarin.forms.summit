using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Summit
{
    public interface IAgendaService
    {
        IEnumerable<AgendaWrapper> GetAgenda();
    }

    public class AgendaService : ServiceBase, IAgendaService
    {
        public IEnumerable<AgendaWrapper> GetAgenda()
        {
            using (var realm = GetRealmInstance())
            {
                var result = new List<AgendaWrapper>();
                var agendas = realm.All<Agenda>().ToList();
                foreach (var item in agendas)
                {
                    var agendaWrapper = item.ConvertTo<AgendaWrapper>();
                    agendaWrapper.TimeLine = item.TimeLine.Select(s =>
                    {
                        var timeLine = new TimeLineWrapper { Hora = s.Hora, Id = s.Id, Titulo = s.Titulo };
                        timeLine.Palestra = s.Palestrantes.Any();
                        timeLine.Descricao = timeLine.Palestra ?
                        string.Join(", ", s.Palestrantes.AsEnumerable().Select(p => p.Nome))
                        : s.Descricao;

                        return timeLine;
                    }).ToList();
                    result.Add(agendaWrapper);
                }
                return result;
            }
        }

    }
}

