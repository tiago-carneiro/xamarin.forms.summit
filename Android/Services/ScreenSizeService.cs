
using Android.App;
using Android.Util;

namespace Xamarin.Summit.Android
{
    public class ScreenSizeService : IScreenSizeService
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public ScreenSizeService()
        {
            DisplayMetrics displaymetrics = new DisplayMetrics();
            (MainApplication.CurrentContext as Activity).WindowManager.DefaultDisplay.GetMetrics(displaymetrics);
            Width = displaymetrics.WidthPixels;
            Height = displaymetrics.HeightPixels;
        }
    }
}