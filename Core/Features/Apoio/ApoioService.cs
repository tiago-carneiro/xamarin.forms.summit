using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Summit
{
    public interface IApoioService
    {
        IEnumerable<ApoioWrapper> GetApoio();
    }

    public class ApoioService : ServiceBase, IApoioService
    {
        public IEnumerable<ApoioWrapper> GetApoio()
        {
            using (var realm = GetRealmInstance())
            {
                var apoio = realm.All<Apoio>().AsEnumerable();
                return apoio.Select(s => s.ConvertTo<ApoioWrapper>()).ToList();
            }
        }
    }
}
