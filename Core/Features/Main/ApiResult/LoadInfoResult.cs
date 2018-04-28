namespace Xamarin.Summit
{
    public enum LoadInfoStatus
    {
        None,
        Updated,
        Error
    }

    public class LoadInfoResult
    {
        public LoadInfoResult(LoadInfoStatus status, string message = "")
        {
            Message = message;
            Status = status;
        }

        public LoadInfoStatus Status { get; private set; }

        public string Message { get; private set; }
    }
}
