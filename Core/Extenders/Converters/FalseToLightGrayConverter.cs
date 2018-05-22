using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class FalseToLightGrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (!(bool)value) ? "#ebebeb" : VisualElement.BackgroundColorProperty.DefaultValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
