using Autofac.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Xamarin.Summit
{
    public partial class App : Application
    {
        public static int DisplayScreenWidth { get; set; }

        public App(params IModule[] platformSpecificModules)
        {
            InitializeComponent();
            PrepareContainer(platformSpecificModules);
            ConfigureMap();
            RegisterAppCenter();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitializeAsyc();
        }

        void PrepareContainer(IModule[] platformSpecificModules)
        {
            ViewModelLocator.Instance.RegisterModules(platformSpecificModules);

            ViewModelLocator.Instance.Register<INavigationService, NavigationService>();

            ViewModelLocator.Instance.Register<IAgendaService, AgendaService>();
            ViewModelLocator.Instance.Register<IApoioService, ApoioService>();
            ViewModelLocator.Instance.Register<IInfoService, InfoService>();
            ViewModelLocator.Instance.Register<ISummitInfoService, SummitInfoService>();
            ViewModelLocator.Instance.Register<IPalestraService, PalestraService>();

            ViewModelLocator.Instance.Register<MainViewModel>();
            ViewModelLocator.Instance.Register<InfoViewModel>();
            ViewModelLocator.Instance.Register<AgendaViewModel>();
            ViewModelLocator.Instance.Register<ApoioViewModel>();
            ViewModelLocator.Instance.Register<PalestraViewModel>();

            ViewModelLocator.Instance.Build();
        }

        void ConfigureMap()
        {
            NavigationService.ConfigureMap<MainViewModel, MainPage>();
            NavigationService.ConfigureMap<InfoViewModel, InfoPage>();
            NavigationService.ConfigureMap<AgendaViewModel, AgendaPage>();
            NavigationService.ConfigureMap<ApoioViewModel, ApoioPage>();
            NavigationService.ConfigureMap<PalestraViewModel, PalestraPage>();
        }

        void RegisterAppCenter()
        => AppCenter.Start(ConstantHelper.AppCenterKey,
                  typeof(Analytics), typeof(Crashes), typeof(Push));

        async Task InitializeAsyc()
            => await ViewModelLocator.Instance.Resolve<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
