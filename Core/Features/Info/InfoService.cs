using System.Linq;

namespace Xamarin.Summit
{
    public interface IInfoService
    {
        InformacaoWrapper GetInformacao();
    }

    public class InfoService : ServiceBase, IInfoService
    {
        public InformacaoWrapper GetInformacao()
        {
            var realm = GetRealmInstance();
            var informacao = realm.All<Informacao>()?.FirstOrDefault();
            if (informacao == null)
                return null;

            var result = informacao.ConvertTo<InformacaoWrapper>();
            result.Notas = informacao.Notas.Select(s => s.ConvertTo<NotaWrapper>());
            result.Organizacao = informacao.Organizacao.Select(s => s.ConvertTo<OrganizacaoWrapper>());
            return result;
        }
    }
}
