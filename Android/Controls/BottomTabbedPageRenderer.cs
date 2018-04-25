using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V4.View;
using Android.Views;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Summit;
using Xamarin.Summit.Android;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace Xamarin.Summit.Android
{
    public class BottomTabbedPageRenderer : TabbedPageRenderer
    {
        public BottomTabbedPageRenderer(Context context) : base(context)
        {
        }


        bool setup;
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (setup)
                return;

            if (e.PropertyName == "Renderer")
            {
                var pager = (ViewPager)ViewGroup.GetChildAt(0);
                var layout = (TabLayout)ViewGroup.GetChildAt(1);
                setup = true;

                ColorStateList colors = null;
                if ((int)Build.VERSION.SdkInt >= 23)
                    colors = Resources.GetColorStateList(Resource.Drawable.icon_tab, MainApplication.CurrentContext.Theme);
                else
                    colors = Resources.GetColorStateList(Resource.Drawable.icon_tab);                

                for (int i = 0; i < layout.TabCount; i++)
                {
                    var tab = layout.GetTabAt(i);
                    var icon = tab.Icon;
                    if (icon != null)
                    {
                        icon = DrawableCompat.Wrap(icon);
                        DrawableCompat.SetTintList(icon, colors);
                    }
                }
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            InvertLayoutThroughScale();
            base.OnLayout(changed, l, t, r, b);
        }

        void InvertLayoutThroughScale()
        {
            ViewGroup.ScaleY = -1;

            TabLayout tabLayout = null;
            ViewPager viewPager = null;

            for (int i = 0; i < ChildCount; ++i)
            {
                var view = GetChildAt(i);
                if (view is TabLayout) tabLayout = (TabLayout)view;
                else if (view is ViewPager) viewPager = (ViewPager)view;
            }

            tabLayout.ScaleY = viewPager.ScaleY = -1;
            viewPager.SetPadding(0, -tabLayout.MeasuredHeight, 0, 0);
        }
    }
}