using Android.Content;
using Android.Net;

namespace Xamarin.Summit.Android
{
    public class InternetConnectionService : IInternetConnectionService
    {
        public bool IsConnected
        {
            get
            {
                ConnectivityManager cm = (ConnectivityManager)MainApplication.CurrentContext.GetSystemService(Context.ConnectivityService);
                NetworkInfo netInfo = cm.ActiveNetworkInfo;
                return netInfo != null && netInfo.IsConnectedOrConnecting;
            }
        }
    }
}