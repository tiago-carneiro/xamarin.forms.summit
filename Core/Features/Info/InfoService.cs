using System.Linq;

namespace Xamarin.Summit
{
    public interface IInfoService
    {
        InformacaoWrapper GetItem();
    }

    public class InfoService : ServiceBase, IInfoService
    {
        public InformacaoWrapper GetItem()
        {
            using (var realm = GetRealmInstance())
            {
                var informacao = realm.All<Informacao>().FirstOrDefault();
                if (informacao == null)
                    return null;

                var result = informacao.ConvertTo<InformacaoWrapper>();
                result.Notas = informacao.Notas.Select(s => s.ConvertTo<NotaWrapper>()).ToList();
                result.Organizacao = informacao.Organizacao.AsEnumerable().Select(s =>
                                        s.ConvertTo<OrganizacaoWrapper>()).ToList();
                return result;
            }
        }
    }
}
