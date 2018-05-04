namespace Xamarin.Summit
{
    public partial class InfoPage : TabbedItemPage
    {
        public InfoPage() : base(typeof(InfoViewModel))
        {
            InitializeComponent();
            //listView.ItemSelected += (s, e)
            //    => listView.SelectedItem = null;
        }
    }
}