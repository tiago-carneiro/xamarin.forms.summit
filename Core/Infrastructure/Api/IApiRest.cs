using Refit;
using System;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    [Headers("Content-Type: application/json")]
    public interface IApiRest
    {
        [Get("/api/info")]
        Task<XamarinInfoResult> GetInfoAsync(string code, string dt);
    }
}
