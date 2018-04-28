using System;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public abstract class TabbedItemPage : ContentPage
    {
        bool _hasInitialized;

        protected TabbedItemPage(Type viewModelType)
        {
            BindingContext = ViewModelLocator.Instance.Resolve(viewModelType);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (_hasInitialized)
                return;
            _hasInitialized = true;

            await (BindingContext as ViewModelBase)?.InitializeAsync();
        }
    }
}
