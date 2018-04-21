
using System.Threading.Tasks;
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

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        void RegisterDependency()
            => DependencyService.Register<INavigationService, NavigationService>();

        void RegisterRoutes()
            => NavigationService.ConfigureMap<MainViewModel, MainPage>();

        async void InitializeAsyc()
            => await DependencyService.Get<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
