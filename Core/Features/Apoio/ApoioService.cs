using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IApoioService
    {
        Task<IEnumerable<ApoioWrapper>> GetApoioAsync();
    }

    public class ApoioService : ServiceBase, IApoioService
    {
        public async Task<IEnumerable<ApoioWrapper>> GetApoioAsync()
            => await Task.Run(() =>
            {
                using (var realm = GetRealmInstance())
                {
                    var apoio = realm.All<Apoio>().ToList();
                    return apoio.Select(s => s.ConvertTo<ApoioWrapper>()).ToList();
                }
            });
    }
}
