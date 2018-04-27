using Refit;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    [Headers("Content-Type: application/json")]
    public interface IApiRest
    {
        [Get("/api/info")]
        Task<XamarinInfoResult> GetInfo();
    }
}
