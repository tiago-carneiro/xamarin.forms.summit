namespace Xamarin.Summit
{
    public partial class MainPage : BottomTabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = (CurrentPage.BindingContext as BaseViewModel).Title;
        }
    }
}
