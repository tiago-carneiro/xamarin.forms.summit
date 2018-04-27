using System.Net;

namespace Xamarin.Summit
{
    public static class ApiResult
    {
        internal static ApiResult<T> Create<T>(T data, bool success, HttpStatusCode statusCode, string message = "")
            => new ApiResult<T>(data, success, statusCode, message);
    }

    public class ApiResult<T>
    {
        public ApiResult(T data, bool success, HttpStatusCode statusCode, string message = "")
        {
            Data = data;
            Message = message;
            Success = success;
            StatusCode = statusCode;
        }

        public T Data { get; private set; }

        public bool Success { get; private set; }

        public string Message { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }
    }
}
