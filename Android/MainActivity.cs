
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Microsoft.AppCenter.Push;

namespace Xamarin.Summit.Android
{
    [Activity(
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            App.DisplayScreenWidth = GetDisplayWidth();

            Push.SetSenderId(ConstantHelper.CloudMessageID);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        int GetDisplayWidth()
        {
            DisplayMetrics displaymetrics = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(displaymetrics);
            return displaymetrics.WidthPixels;
        }
    }
}

