using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IInfoService
    {
        Task<InformacaoWrapper> GetItemAsync();
    }

    public class InfoService : ServiceBase, IInfoService
    {
        public async Task<InformacaoWrapper> GetItemAsync()
            => await Task.Run(() =>
            {
                using (var realm = GetRealmInstance())
                {
                    var informacao = realm.All<Informacao>().FirstOrDefault();
                    if (informacao == null)
                        return null;

                    var result = informacao.ConvertTo<InformacaoWrapper>();
                    result.Notas = informacao.Notas.Select(s => s.ConvertTo<NotaWrapper>()).ToList();
                    result.Organizacao = informacao.Organizacao.AsEnumerable().Select(s => s.ConvertTo<OrganizacaoWrapper>()).ToList();
                    return result;
                }
            });
    }
}
