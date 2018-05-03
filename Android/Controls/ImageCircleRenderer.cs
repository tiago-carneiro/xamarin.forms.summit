using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Summit;
using Xamarin.Summit.Android;

[assembly: ExportRenderer(typeof(ImageCircle), typeof(ImageCircleRenderer))]

namespace Xamarin.Summit.Android
{
    public class ImageCircleRenderer : ImageRenderer
    {
        public ImageCircleRenderer(Context context) : base(context)
        {
        }

        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            var radius = Math.Min(Width, Height) / 2;
            var strokeWidth = 10;
            radius -= strokeWidth / 2;

            //Create path to clip
            var path = new Path();
            path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
            canvas.Save();
            canvas.ClipPath(path);

            var result = base.DrawChild(canvas, child, drawingTime);

            canvas.Restore();

            // Create path for circle border
            path = new Path();
            path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

            var paint = new Paint();
            paint.AntiAlias = true;
            paint.StrokeWidth = 5;
            paint.SetStyle(Paint.Style.Stroke);
            paint.Color = global::Android.Graphics.Color.White;

            canvas.DrawPath(path, paint);

            //Properly dispose
            paint.Dispose();
            path.Dispose();
            return result;
        }
    }
}