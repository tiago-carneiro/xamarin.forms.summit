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

            RegisterTypes();
            ConfigureMap();

            InitializeAsyc();
        }

        void RegisterTypes()
        {
            ViewModelLocator.Instance.Register<INavigationService, NavigationService>();

            ViewModelLocator.Instance.Register<MainViewModel>();
            ViewModelLocator.Instance.Register<InfoViewModel>();
            ViewModelLocator.Instance.Register<AgendaViewModel>();
            ViewModelLocator.Instance.Register<ApoioViewModel>();

            ViewModelLocator.Instance.Build();
        }

        void ConfigureMap()
        {
            NavigationService.ConfigureMap<MainViewModel, MainPage>();
            NavigationService.ConfigureMap<InfoViewModel, InfoPage>();
            NavigationService.ConfigureMap<AgendaViewModel, AgendaPage>();
            NavigationService.ConfigureMap<ApoioViewModel, ApoioPage>();
        }

        async void InitializeAsyc()
            => await ViewModelLocator.Instance.Resolve<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
