using UIKit;

namespace Xamarin.Summit.iOS
{
    public class ScreenSizeService : IScreenSizeService
    {
        public int Height
        {
            get
            {
                return (int)(UIApplication.SharedApplication.KeyWindow.Bounds.Size.Height * UIApplication.SharedApplication.KeyWindow.ContentScaleFactor);
            }
        }

        public int Width
        {
            get
            {
                var width = UIApplication.SharedApplication.KeyWindow.Bounds.Size.Width;
                var scale = UIApplication.SharedApplication.KeyWindow.ContentScaleFactor;
                return (int)(width * scale);
            }
        }
    }
}