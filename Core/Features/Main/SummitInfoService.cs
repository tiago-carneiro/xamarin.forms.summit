using Newtonsoft.Json.Linq;
using Realms;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface ISummitInfoService
    {
        Task<LoadInfoResult> LoadInformacoesAsync();
    }

    public class SummitInfoService : ServiceBase, ISummitInfoService
    {
        IApiRest Api => RestService.For<IApiRest>(ConstantHelper.ApiUrl);

        public async Task<LoadInfoResult> LoadInformacoesAsync()
        {
            try
            {
                using (var realm = GetRealmInstance())
                {
                    var dataAtualizacao = realm.Find<KeyValueStorage>(KeyValueStorage.DataAtualizacao)?.Value ?? ConstantHelper.UpdateDateDefault;

                    XamarinInfoResult xamarinInfoResult;

                    xamarinInfoResult = JObject.Parse("{\"dataAtualizacao\":\"2018-04-01\",\"informacoes\":{\"titulo\":\"XAMARIN SUMMIT 2018\",\"subTitulo\":\"7 e 8 de Junho, Microsoft São Paulo\",\"descricao\":\"Dois dias de troca de conhecimento e discussões sobre desenvolvimento e cases utilizando a plataforma Xamarin.\",\"local\":\"O evento vai acontecer nos auditórios da Microsoft Brasil, localizado na Av das Nações Unidas, 12901 – Torre Norte – 31º Andar\",\"lat\":\" - 23.609916\",\"lon\":\" - 46.697312\",\"organizacao\":[\"William S. Rodriguez\",\"Angelo Belchior\",\"Ricardo Dorta\",\"William Barbosa\",\"Mahmoud Ali\"],\"notas\":[{\"titulo\":\"Público Alvo\",\"descricao\":\"O evento é destinado a desenvolvedores de software, estudantes, arquitetos, testers, empreendedores, parceiros e gestores com interesse na plataforma Xamarin.\"},{\"titulo\":\"Conteúdo\",\"descricao\":\"Do básico para o avançado, você vai participar de um dia de imersão, e conhecer tudo sobre desenvolvimento móvel com Xamarin.\"},{\"titulo\":\"Comunidade e Networking\",\"descricao\":\"O é um grande encontro da comunidade brasileira de desenvolvedores Xamarin, permitindo um ambiente totalmente favorável a troca de experiências e networking.\"}]},\"agenda\":[{\"titulo\":\"Dia 1\",\"descricao\":\"7 de Junho\",\"timeline\":[{\"hora\":\"08h00\",\"titulo\":\"Credenciamento e Welcome Coffee\",\"descricao\":\"Durante o credenciamento os participantes serão recebidos com um delicioso Welcome Coffee\",\"palestrante\":null},{\"hora\":\"09h00\",\"titulo\":\"Keynote\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"09h40\",\"titulo\":\"Utilizando Machine Learning nos seus Apps Xamarin\",\"descricao\":\"Saiba como utilizar todo o poder de bibliotecas como CoreML e TensorFlow para fazer com que seus aplicativos tirem proveito de modelos de aprendizado de máquina treinados para resolver problemas como reconhecimento de imagens.\",\"palestrante\":\"Angelo Belchior\"},{\"hora\":\"10h20\",\"titulo\":\"Como construir sua aplicação utilizando módulos\",\"descricao\":\"Demonstração de como podemos construir aplicações onde parte de suas funcionalidades estão em módulos e como isso pode ser benéfico para a distribuição e consumo da sua aplicação.\",\"palestrante\":\"Rodrigo Amaro dos Santos Amaral\"},{\"hora\":\"11h00\",\"titulo\":\"Desenvolvendo interfaces \\\"like a boss\\\" \",\"descricao\":\"O objetivo principal dessa palestra é analisarmos as interfaces de alguns aplicativos, entendermos como elas podem ser estruturadas e colocar a mão na massa para fazer algo bem similar. Quem sabe não sai uma cópia de um WhatsApp ou Twitter!\",\"palestrante\":\"Ione Souza Junior\"},{\"hora\":\"12h00\",\"titulo\":\"Almoço\",\"descricao\":\"Intervalo para o almoço livre.\",\"palestrante\":null},{\"hora\":\"13h00\",\"titulo\":\"Build your next app with MvvmCross 6\",\"descricao\":\"MvvmCross 6 has finally arrived! In this session we will explore how can it help you build polished, scalable apps without compromise. It doesn’t matter if you use Xamarin.Forms or the traditional approach, MvvmCross 6 will supercharge your development!\",\"palestrante\":\"Nicolas Milcoff\"},{\"hora\":\"13h40\",\"titulo\":\"Dados escaláveis e seguros com Cosmos DB e Xamarin\",\"descricao\":\"Entendo o que é o Cosmos DB, quais as suas caracteristicas e como ele pode eliminar a necessidade de uma API para aplicativos CRUD based. Pretendo demonstrar a criação de uma schema e collection de dados no portal do azure e a integração com um aplicativo xamarin consultando e salvando informações no Cosmos DB criado.\",\"palestrante\":\"Robson Soares Amorim\"},{\"hora\":\"15h00\",\"titulo\":\"CSS no Xamarin.Forms\",\"descricao\":\"Use o CSS como você faz na web, só que agora em um aplicativo Xamarin.Forms.\",\"palestrante\":\"Juliano Custódio\"},{\"inicio\":\"15h40\",\"titulo\":\"Coffee break\",\"descricao\":\"Ufa! Uma pequena pausa para você esticar as pernas, tomar um café e conhecer novas pessoas ;)\",\"palestrante\":null},{\"hora\":\"16h20\",\"titulo\":\"Case, Xamarin no mundo real 1\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"17h00\",\"titulo\":\"Case, Xamarin no mundo real 2\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"17h40\",\"titulo\":\"Encerramento\",\"descricao\":\"Fecharemos o dia com um sorteio de brindes\",\"palestrante\":null},{\"hora\":\"18:20\",\"titulo\":\"Fim\",\"descricao\":\"Até outro dia.\",\"palestrante\":null}]},{\"titulo\":\"Dia 2\",\"descricao\":\"8 de Junho\",\"timeline\":[{\"hora\":\"08h00\",\"titulo\":\"Credenciamento e Welcome Coffee\",\"descricao\":\"Durante o credenciamento os participantes serão recebidos com um delicioso Welcome Coffee.\",\"palestrante\":null},{\"hora\":\"09h40\",\"titulo\":\"MissingMethodTalkNameException ou como fazer o Linker se comportar!\",\"descricao\":\"Aguarde!\",\"palestrante\":\"William Barbosa\"},{\"hora\":\"10h20\",\"titulo\":\"Aplicações resilientes. Seu app funcionando offline.\",\"descricao\":\"Aguarde!\",\"palestrante\":\"Ricardo Dorta\"},{\"hora\":\"11h00\",\"titulo\":\"Automatizando tudo no mundo mobile com Fastlane\",\"descricao\":\"Ferramentas no mundo mobile ainda não são tão maduras quanto às do mundo Web, isso acaba nos fazendo repetir muitas tarefas diariamente, ainda mais quando estamos falando de múltiplas plataformas: iOS, Android e UWP são completamente diferentes e trazem complexidades diferentes.  O fastlane nos ajuda a diminuir essas tarefas chatas, monótonas e repetitivas, tudo com comandos simples de usar e de entender. Vou mostrar como fastlane consegue cortar HORAS de tarefas chatas pra que você possa focar no que realmente importa: seu produto.\",\"palestrante\":\"Mahmoud Ali\"},{\"hora\":\"12h00\",\"titulo\":\"Almoço\",\"descricao\":\"Intervalo para o almoço livre.\",\"palestrante\":null},{\"hora\":\"13h00\",\"titulo\":\"Palestra\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"13h40\",\"titulo\":\"Palestra\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"15h00\",\"titulo\":\"Nem você (nem ninguém) entende Async de verdade\",\"descricao\":\"Aguarde!\",\"palestrante\":\"William Barbosa,Ricardo Dorta\"},{\"hora\":\"15h40\",\"titulo\":\"Coffee break\",\"descricao\":\"Ufa! Uma pequena pausa para você esticar as pernas, tomar um café e conhecer novas pessoas ;)\",\"palestrante\":null},{\"hora\":\"16h20\",\"titulo\":\"Case, Xamarin no mundo real\",\"descricao\":\"Aguarde!\",\"palestrante\":null},{\"hora\":\"17h00\",\"titulo\":\"Ask the Experts\",\"descricao\":\"Pergunte o que quiser para nossos especialistas, em um painel de questões!\",\"palestrante\":null},{\"hora\":\"17h40\",\"titulo\":\"Encerramento\",\"descricao\":\"Fecharemos o dia com um sorteio de brindes\",\"palestrante\":null},{\"hora\":\"18:20\",\"titulo\":\"Fim\",\"descricao\":\"Até a próxima edição\",\"palestrante\":null}]}],\"apoio\":[{\"nome\":\"Microsoft\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/microsoft-1240x860.png\",\"link\":\"https://www.microsoft.com/pt-br\",\"categoria\":\"Diamond\",\"ordem\":1},{\"nome\":\"Arctouch\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/arctouch-1-800x400.png\",\"link\":\"https://arctouch.com/\",\"categoria\":\"Silver\",\"ordem\":2}],\"pessoas\":[{\"nome\":\"William S. Rodriguez\",\"titulo\":\"Microsoft MVP\",\"descricao\":\"Dad of 3 girls and 1 boy, speaker, mobile developer, @Microsoft & @xamarinhq MVP, Co-Founder/Host @MonkeyNightsDev community builder and @capiconf organizer\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/c3cpwweb-400x400.jpg\",\"link\":\"https://www.linkedin.com/in/willbuildapps/\"},{\"nome\":\"Angelo Belchior\",\"titulo\":\"Microsoft MVP\",\"descricao\":\"Microsoft MVP, Xamarin Moonwalker, @MonkeyNightsDev Co-Founder, .Net Developer, Lead Software Developer @ ESX\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/28468467-10155662951649355-8279225470067203996-n-240x240.jpg\",\"link\":\"https://twitter.com/angelobelchior\"},{\"nome\":\"Ricardo Dorta\",\"titulo\":\"CTO @KCMS\",\"descricao\":\"Apaixonado pela mulher, pelo Tricolor Paulista e por tecnologias como C#, Xamarin e Unity. Co-Founder/Host @MonkeyNightsDev\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/4js9ul9p-400x400-240x240.jpg\",\"link\":\"https://twitter.com/dortaway\"},{\"nome\":\"William Barbosa\",\"titulo\":\"Microsoft MVP\",\"descricao\":\"Desenvolvedor Mobile Microsoft MVP, Palestrante, Entusiasta de Xamarin Co-Founder/Host do Monkey Nights Podcast/Webcast e contribuidor do Framework MvvmCross\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/whatsapp-image-2018-04-23-at-09.21.45-240x320.jpg\",\"link\":\"https://twitter.com/willdotnet\"},{\"nome\":\"Mahmoud Ali\",\"titulo\":\"Xamarin Certified Mobile Developer\",\"descricao\":\"Xamarin Certified Mobile Developer, Microsoft Specialist in C#, Apache Committer, open source enthusiast, hardcore gamer, and beer hunter\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/oe101mw-400x400-240x240.jpg\",\"link\":\"https://twitter.com/akamud\"},{\"nome\":\"Juliano Custódio\",\"titulo\":\"Xamarin Developer\",\"descricao\":\"É formado em Análise e Desenvolvimento de Sistemas pela FATEC de Sorocaba, Software Developer na empresa Algorama, faz parte da lista de autores do Planet Xamarin, fundador da comunidade Xamarin Sorocaba, palestrante e escreve artigos sobre Xamarin em seu blog.\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/71de9936f2ffbc93e9918066479331f1-240x240.jpg\",\"link\":null},{\"nome\":\"Rodrigo Amaro dos Santos Amaral\",\"titulo\":\"Xamarin Developer\",\"descricao\":\"Curto tecnologia desde os 8 anos e arrisco desenvolvimento já a 15 anos, trabalhando de legados à ponta da tecnologia.\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/0-210x210.jpg\",\"link\":\"https://www.twitter.com/jbravobr\"},{\"nome\":\"Nicolas Milcoff\",\"titulo\":\"COO @ DGenix\",\"descricao\":\"MvvmCross Maintainer\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/12127846-240x240.jpg\",\"link\":\"https://twitter.com/nmilcoff\"},{\"nome\":\"Ione Souza Junior\",\"titulo\":\"Xamarin Developer\",\"descricao\":\"Graduado em Análise e Desenvolvimento de Sistemas pela Católica SC e especializado em Tecnologias Web pela PUC PR. Desenvolvedor web e mobile. Curioso e apreciador de assuntos relacionados a qualidade e testes de software.\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/519642-240x240.png\",\"link\":\"http://twiter.com/ionixjunior\"},{\"nome\":\"Robson Soares Amorim\",\"titulo\":\"Xamarin Developer\",\"descricao\":\"Desenvolvedor xamarin na Lambda3. Formado em sistemas de informação na UNIP em 2012. Gosto de contribuir com a comunidade com posts, podcasts e palestras. Sempre na busca pela troca de conhecimentos!\",\"imagem\":\"http://xamarinsummit.com.br/assets/images/wei0n-ms-240x240.jpg\",\"link\":\"https://twitter.com/AmorimRob\"}]}").
                       ToObject<XamarinInfoResult>();
                    await Task.Delay(TimeSpan.FromSeconds(7));

                    //xamarinInfoResult = await Api.GetInfoAsync(ConstantHelper.Code, dataAtualizacao);
                    //if (xamarinInfoResult == null)
                    //    return new LoadInfoResult(LoadInfoStatus.None);
                    
                    using (var tran = realm.BeginWrite())
                    {
                        CleanDataBase(realm);
                        var pessoas = xamarinInfoResult.Pessoas.Select(s => s.ConvertTo<Pessoa>()).ToList();

                        var informacoes = GetInformacoes(xamarinInfoResult.Informacoes);

                        foreach (var item in xamarinInfoResult.Informacoes.Organizacao)
                        {
                            var pessoa = pessoas.FirstOrDefault(w => w.Nome == item);
                            pessoa.Organizacao = informacoes;
                        }

                        var apoio = xamarinInfoResult.Apoio.Select(s => s.ConvertTo<Apoio>());
                        var agendas = GetAgendas(xamarinInfoResult.Agenda, pessoas);

                        pessoas.ToList().ForEach(p => realm.Add(p));
                        realm.Add(informacoes, true);
                        apoio.ToList().ForEach(a => realm.Add(a, true));
                        agendas.ToList().ForEach(a => realm.Add(a, true));

                        realm.Add(new KeyValueStorage
                        {
                            Key = KeyValueStorage.DataAtualizacao,
                            Value = xamarinInfoResult.DataAtualizacao
                        }, true);

                        tran.Commit();
                    }

                    return new LoadInfoResult(LoadInfoStatus.Updated);
                }
            }
            catch
            {
                return new LoadInfoResult(LoadInfoStatus.Error, Resource.InternalServerError);
            }
        }

        Informacao GetInformacoes(InformacoesResult informacaoResult)
        {
            var informacao = informacaoResult.ConvertTo<Informacao>();
            informacaoResult.Notas.ToList().ForEach(n =>
                informacao.Notas.Add(n.ConvertTo<Nota>()));

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

                foreach (var item in nomes)
                {
                    var pessoa = pessoas.FirstOrDefault(w => w.Nome == item);
                    pessoa.TimeLine.Add(timeLine);
                }
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
