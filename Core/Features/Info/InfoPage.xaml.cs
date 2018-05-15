using Xamarin.Forms;

namespace Xamarin.Summit
{
    public partial class InfoPage : TabbedItemPage
    {
        public InfoPage() : base(typeof(InfoViewModel))
            => InitializeComponent();

        private void OpenMap_Clicked(object sender, System.EventArgs e)
            => (BindingContext as InfoViewModel).OpenMapCommand.Execute((sender as Button).BindingContext);
    }
}