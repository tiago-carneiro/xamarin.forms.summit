using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IPalestraService
    {
        Task<PalestraWrapper> GetPalestraAsync(string id);
    }

    public class PalestraService : ServiceBase, IPalestraService
    {
        public async Task<PalestraWrapper> GetPalestraAsync(string id)
        {
            using (var realm = GetRealmInstance())
            {
                var timeLine = realm.Find<TimeLine>(id);
                var palestra = timeLine.ConvertTo<PalestraWrapper>();
                palestra.Palestrantes = timeLine.Palestrantes.AsEnumerable().Select(s => s.ConvertTo<PalestranteWrapper>()).ToList();
                return palestra;
            }
        }
    }
}
