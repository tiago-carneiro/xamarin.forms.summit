namespace Xamarin.Summit
{
    public class MainViewModel : BaseViewModel
    {
        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        public MainViewModel() : base(Resource.MainTitle)
        {
            PageTitle = Resource.MainTitle;
        }
    }
}
