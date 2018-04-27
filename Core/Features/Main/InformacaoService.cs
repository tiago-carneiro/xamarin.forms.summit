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

    public class InformacaoService : IInformacaoService
    {
        ulong SchemaVersion => 0;
        IApiRest Api => RestService.For<IApiRest>(ConstantHelper.ApiUrl);

        public async Task LoadInformacoesAsync()
        {
            var realm = GetRealmInstance();
            var dataAtualizacao = realm.Find<KeyValueStorage>(KeyValueStorage.DataAtualizacao)?.Value ?? ConstantHelper.UpdateDateDefault;

            var xamarinInfoResult = await Api.GetInfoAsync(ConstantHelper.Code, dataAtualizacao);
            if (xamarinInfoResult == null)
                return;

            var pessoas = GetPessoas(xamarinInfoResult.Pessoas);
            var informacoes = GetInformacoes(xamarinInfoResult.Informacoes, pessoas);
            var apoio = GetApoios(xamarinInfoResult.Apoio);
            var agendas = GetAgendas(xamarinInfoResult.Agenda, pessoas);

            using (var tran = realm.BeginWrite())
            {
                CleanDataBase(realm);

                realm.Add(informacoes);
                apoio.ToList().ForEach(a => realm.Add(a));
                agendas.ToList().ForEach(a => realm.Add(a));

                realm.Add(new KeyValueStorage { Key = KeyValueStorage.DataAtualizacao, Value = xamarinInfoResult.DataAtualizacao });

                tran.Commit();
            }
        }

        Informacao GetInformacoes(InformacoesResult informacaoResult, IEnumerable<Pessoa> pessoas)
        {
            var informacao = new Informacao
            {
                Descricao = informacaoResult.Descricao,
                Lat = informacaoResult.Lat,
                Local = informacaoResult.Local,
                Lon = informacaoResult.Lon,
                SubTitulo = informacaoResult.SubTitulo,
                Titulo = informacaoResult.Titulo
            };

            GetNotas(informacaoResult.Notas).ToList().ForEach(n => informacao.Notas.Add(n));
            pessoas.Where(w => informacaoResult.Organizacao.Contains(w.Nome)).ToList().ForEach(p => informacao.Organizacao.Add(p));

            return informacao;
        }

        IEnumerable<Nota> GetNotas(IEnumerable<NotaResult> notasResult)
            => notasResult.Select(s => new Nota { Descricao = s.Descricao, Titulo = s.Titulo });

        IEnumerable<Apoio> GetApoios(IEnumerable<ApoioResult> apoiosResult)
            => apoiosResult.Select(s => new Apoio { Categoria = s.Categoria, Imagem = s.Imagem, Link = s.Link, Nome = s.Nome, Ordem = s.Ordem });

        IEnumerable<Pessoa> GetPessoas(IEnumerable<PessoaResult> pessoasResult)
            => pessoasResult.Select(s => new Pessoa { Descricao = s.Descricao, Imagem = s.Imagem, Link = s.Link, Nome = s.Nome, Titulo = s.Titulo });

        IEnumerable<Agenda> GetAgendas(IEnumerable<AgendaResult> agendasResult, IEnumerable<Pessoa> pessoas)
            => agendasResult.Select(s => GetAgenda(s, pessoas));

        Agenda GetAgenda(AgendaResult agendaResult, IEnumerable<Pessoa> pessoas)
        {
            var agenda = new Agenda { Descricao = agendaResult.Descricao, Titulo = agendaResult.Titulo };
            GetTimeLines(agendaResult.TimeLine, pessoas).ToList().ForEach(tl => agenda.TimeLine.Add(tl));
            return agenda;
        }

        IEnumerable<TimeLine> GetTimeLines(IEnumerable<TimeLineResult> timeLineResult, IEnumerable<Pessoa> pessoas)
            => timeLineResult.Select(s => GetTimeLine(s, pessoas)).ToList();

        TimeLine GetTimeLine(TimeLineResult timeLineResult, IEnumerable<Pessoa> pessoas)
        {
            var timeLine = new TimeLine { Descricao = timeLineResult.Descricao, Hora = timeLineResult.Hora, Titulo = timeLineResult.Titulo };
            if (!string.IsNullOrEmpty(timeLineResult.Palestrante))
            {
                var nomes = timeLineResult.Palestrante.Split(',');
                pessoas.Where(w => nomes.Contains(w.Nome)).ToList().ForEach(p => timeLine.Palestrantes.Add(p));
            }
            return timeLine;
        }

        Realm GetRealmInstance()
        {
            var config = new RealmConfiguration { SchemaVersion = SchemaVersion };

            #region Migration
            /***** Se houver alguma alteração de classes, deverá ser efetuado o Migration *****/
            //config.MigrationCallback = (migration, oldSchemaVersion) =>
            //{
            //    if (oldSchemaVersion < SchemaVersion)
            //    {
            //        if (oldSchemaVersion < 1)
            //        {
            //            var newObj = migration.NewRealm.All<Class>();
            //            // Use the dynamic api for oldPeople so we can access
            //            // .FirstName and .LastName even though they no longer
            //            // exist in the class definition.
            //            var oldObj = migration.OldRealm.All("className");
            //            for (var i = 0; i < newObj.Count(); i++)
            //            {
            //                var old = oldObj.ElementAt(i);
            //                var new = newObj.ElementAt(i);
            //            }
            //        }
            //    }
            //};
            #endregion

            config.ObjectClasses = new[]
            {
                typeof(Agenda),
                typeof(Apoio),
                typeof(Informacao),
                typeof(KeyValueStorage),
                typeof(Nota),
                typeof(Pessoa),
                typeof(TimeLine)
            };

            return Realm.GetInstance(config);
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
