using Realms;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IInformacaoService
    {
        Task LoadInformacoesAsync();
    }

    public class InformacaoService : ServiceBase, IInformacaoService
    {
        IApiRest Api => RestService.For<IApiRest>(ConstantHelper.ApiUrl);

        public async Task LoadInformacoesAsync()
        {
            var realm = GetRealmInstance();
            var dataAtualizacao = realm.Find<KeyValueStorage>(KeyValueStorage.DataAtualizacao)?.Value ?? ConstantHelper.UpdateDateDefault;

            var xamarinInfoResult = await Api.GetInfoAsync(ConstantHelper.Code, dataAtualizacao);
            if (xamarinInfoResult == null)
                return;

            var pessoas = xamarinInfoResult.Pessoas.Select(s => s.ConvertTo<Pessoa>());
            var informacoes = GetInformacoes(xamarinInfoResult.Informacoes, pessoas);
            var apoio = xamarinInfoResult.Apoio.Select(s => s.ConvertTo<Apoio>());
            var agendas = GetAgendas(xamarinInfoResult.Agenda, pessoas);

            using (var tran = realm.BeginWrite())
            {
                CleanDataBase(realm);

                realm.Add(informacoes);
                apoio.ToList().ForEach(a => realm.Add(a));
                agendas.ToList().ForEach(a => realm.Add(a));

                realm.Add(new KeyValueStorage
                {
                    Key = KeyValueStorage.DataAtualizacao,
                    Value = xamarinInfoResult.DataAtualizacao
                });

                tran.Commit();
            }
        }

        Informacao GetInformacoes(InformacoesResult informacaoResult, IEnumerable<Pessoa> pessoas)
        {
            var informacao = informacaoResult.ConvertTo<Informacao>();
            informacaoResult.Notas.ToList().ForEach(n =>
                informacao.Notas.Add(n.ConvertTo<Nota>()));

            pessoas.Where(w =>
                informacaoResult.Organizacao.Contains(w.Nome)
                ).ToList().ForEach(p =>
                    informacao.Organizacao.Add(p));

            return informacao;
        }

        IEnumerable<Agenda> GetAgendas(IEnumerable<AgendaResult> agendasResult, IEnumerable<Pessoa> pessoas)
            => agendasResult.Select(s => GetAgenda(s, pessoas));

        Agenda GetAgenda(AgendaResult agendaResult, IEnumerable<Pessoa> pessoas)
        {
            var agenda = agendaResult.ConvertTo<Agenda>();
            GetTimeLines(agendaResult.TimeLine, pessoas).ToList().ForEach(tl => agenda.TimeLine.Add(tl));
            return agenda;
        }

        IEnumerable<TimeLine> GetTimeLines(IEnumerable<TimeLineResult> timeLineResult, IEnumerable<Pessoa> pessoas)
            => timeLineResult.Select(s => GetTimeLine(s, pessoas)).ToList();

        TimeLine GetTimeLine(TimeLineResult timeLineResult, IEnumerable<Pessoa> pessoas)
        {
            var timeLine = timeLineResult.ConvertTo<TimeLine>();
            if (!string.IsNullOrEmpty(timeLineResult.Palestrante))
            {
                var nomes = timeLineResult.Palestrante.Split(',');
                pessoas.Where(w =>
                    nomes.Contains(w.Nome)
                ).ToList().ForEach(p =>
                    timeLine.Palestrantes.Add(p));
            }
            return timeLine;
        }

        void CleanDataBase(Realm realm)
        {
            realm.RemoveAll<Agenda>();
            realm.RemoveAll<Apoio>();
            realm.RemoveAll<Informacao>();
            realm.RemoveAll<Nota>();
            realm.RemoveAll<Pessoa>();
            realm.RemoveAll<TimeLine>();
        }
    }
}
