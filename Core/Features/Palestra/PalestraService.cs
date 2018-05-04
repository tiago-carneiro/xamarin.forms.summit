using System.Linq;

namespace Xamarin.Summit
{
    public interface IPalestraService
    {
        PalestraWrapper GetPalestra(string id);
    }

    public class PalestraService : ServiceBase, IPalestraService
    {
        public PalestraWrapper GetPalestra(string id)
        {
            using (var realm = GetRealmInstance())
            {
                var timeLine = realm.Find<TimeLine>(id);
                var palestra = timeLine.ConvertTo<PalestraWrapper>();
                palestra.Palestrantes = timeLine.Palestrantes.AsEnumerable()
                                        .Select(s => s.ConvertTo<PalestranteWrapper>()).ToList();
                return palestra;
            }
        }
    }
}
