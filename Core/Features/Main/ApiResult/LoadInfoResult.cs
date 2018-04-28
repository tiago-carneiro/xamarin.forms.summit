namespace Xamarin.Summit
{
    public class LoadInfoResult
    {
        public LoadInfoResult(bool success, string message = "")
        {
            Message = message;
            Success = success;
        }
        public bool Success { get; private set; }

        public string Message { get; private set; }
    }
}
