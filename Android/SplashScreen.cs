
using Android.App;
using Android.Content.PM;
using Android.Support.V7.App;

namespace Xamarin.Summit.Android
{
    [Activity(
           Label = "@string/app_name"
           , MainLauncher = true
           , Icon = "@drawable/icon"
           , Theme = "@style/Theme.Splash"
           , NoHistory = true
           , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}