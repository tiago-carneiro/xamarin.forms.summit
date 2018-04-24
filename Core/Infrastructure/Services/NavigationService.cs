using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task NavigateBackAsync();
        Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task NavigateAndClearBackStackAsync(Type type, object parameter = null);
        Task OpenModalAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task OpenModalAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task CloseModalAsync();
    }

    public class NavigationService : INavigationService
    {
        readonly Application CurrentApplication = Application.Current;

        static readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void ConfigureMap<TViewModel, TPage>() where TViewModel : BaseViewModel
                                                          where TPage : Page
        {
            if (!_mappings.ContainsKey(typeof(TViewModel)))
            {
                ViewModelLocator.Instance.Register<TViewModel>();
                _mappings.Add(typeof(TViewModel), typeof(TPage));
            }
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
            => await NavigateToAsync(typeof(TViewModel), null, false, false);

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
            => await NavigateToAsync(typeof(TViewModel), parameter, false, false);

        public async Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
            => await NavigateToAsync(typeof(TViewModel), parameter, true, false);

        public async Task NavigateBackAsync()
            => await PopAsync(false);

        async Task NavigateToAsync(Type type, object parameter, bool cleanBackStack, bool modal)
        {
            var page = CreateAndBindPage(type, parameter);

            var navigationPage = CurrentApplication.MainPage as NavigationPage;
            var masterDetailPage = CurrentApplication.MainPage as MasterDetailPage;
            var isMasterDetailpage = masterDetailPage != null;

            if (isMasterDetailpage)
                navigationPage = masterDetailPage.Detail as NavigationPage;

            if (navigationPage == null)
                CurrentApplication.MainPage = new NavigationPage(page);
            else
            {
                if (modal)
                    await navigationPage.Navigation.PushModalAsync(page);
                else
                    await navigationPage.PushAsync(page);
            }

            if (navigationPage != null && cleanBackStack && navigationPage.Navigation.NavigationStack.Count > 0)
            {
                var existingPages = navigationPage.Navigation.NavigationStack.ToList();

                foreach (var existingPage in existingPages)
                {
                    if (existingPage != page)
                        navigationPage.Navigation.RemovePage(existingPage);
                }
            }

            if (isMasterDetailpage)
                masterDetailPage.IsPresented = false;

            await Task.Delay(250);

            if (parameter == null)
                await (page.BindingContext as BaseViewModel).InitializeAsync();
            else
                await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        public async Task NavigateAndClearBackStackAsync(Type type, object parameter = null)
                => await NavigateToAsync(type, parameter, true, false);

        Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");

            return _mappings[viewModelType];
        }

        Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Mapping type for {viewModelType} is not a page");

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;
            return page;
        }

        public async Task OpenModalAsync<TViewModel>() where TViewModel : BaseViewModel
            => await NavigateToAsync(typeof(TViewModel), null, false, true);

        public async Task OpenModalAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
             => await NavigateToAsync(typeof(TViewModel), parameter, false, true);

        public async Task CloseModalAsync()
            => await PopAsync(true);

        async Task PopAsync(bool modal)
        {
            var navigationPage = CurrentApplication.MainPage as NavigationPage;
            var masterDetailPage = CurrentApplication.MainPage as MasterDetailPage;

            if (masterDetailPage != null)
                navigationPage = masterDetailPage.Detail as NavigationPage;

            if (modal)
                await navigationPage.Navigation.PopModalAsync();
            else
                await navigationPage.PopAsync();
        }
    }
}
