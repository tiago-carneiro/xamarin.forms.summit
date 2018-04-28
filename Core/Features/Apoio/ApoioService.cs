using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IApoioService
    {
        Task<IEnumerable<ApoioWrapper>> GetApoioAsync();
    }

    class ApoioService : ServiceBase, IApoioService
    {
        public async Task<IEnumerable<ApoioWrapper>> GetApoioAsync()
            => await Task.Run(() => 
                GetRealmInstance().All<Apoio>()?.
                Select(s => s.ConvertTo<ApoioWrapper>()));
    }
}
