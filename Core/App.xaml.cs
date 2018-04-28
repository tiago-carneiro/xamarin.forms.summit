using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
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
            ConfigurePushNotification();
            RegisterAppCenter();
            InitializeAsyc();
        }

        void RegisterTypes()
        {
            ViewModelLocator.Instance.Register<INavigationService, NavigationService>();

            ViewModelLocator.Instance.Register<IAgendaService, AgendaService>();
            ViewModelLocator.Instance.Register<IApoioService, ApoioService>();
            ViewModelLocator.Instance.Register<IInfoService, InfoService>();
            ViewModelLocator.Instance.Register<ISummitInfoService, SummitInfoService>();

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

        void ConfigurePushNotification()
        {
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }
        }

        void RegisterAppCenter()
        => AppCenter.Start(ConstantHelper.AppCenterKey,
                  typeof(Analytics), typeof(Crashes), typeof(Push));

        async void InitializeAsyc()
            => await ViewModelLocator.Instance.Resolve<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
