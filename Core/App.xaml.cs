using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Xamarin.Summit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterDependency();
            RegisterRoutes();
            InitializeAsyc();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }

        void RegisterDependency()
        {
            ViewModelLocator.Instance.Register<INavigationService, NavigationService>();

            ViewModelLocator.Instance.Register<MainViewModel>();

            ViewModelLocator.Instance.Build();
        }

        void RegisterRoutes()
            => NavigationService.ConfigureMap<MainViewModel, MainPage>();

        async void InitializeAsyc()
            => await ViewModelLocator.Instance.Resolve<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
