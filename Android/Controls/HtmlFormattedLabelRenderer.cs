using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Summit;
using Xamarin.Summit.Android;

[assembly: ExportRenderer(typeof(HtmlFormattedLabel), typeof(HtmlFormattedLabelRenderer))]
namespace Xamarin.Summit.Android
{
    public class HtmlFormattedLabelRenderer : LabelRenderer
    {
        public HtmlFormattedLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlFormattedLabel)Element;
            if (view == null) return;
            ISpanned htmlText;
            var text = view.Text.ToString();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                htmlText = Html.FromHtml(text, Html.FromHtmlModeLegacy);
            else
                htmlText = Html.FromHtml(text);

            Control.SetText(htmlText, TextView.BufferType.Spannable);
        }
    }
}