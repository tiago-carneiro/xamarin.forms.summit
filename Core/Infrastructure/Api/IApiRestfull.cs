using Refit;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    [Headers("Content-Type: application/json")]
    public interface IApiRestfull
    {
        [Get("/api/info")]
        Task<XamarinInfoResult> GetInfo();
    }
}
