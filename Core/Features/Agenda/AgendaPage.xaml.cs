using Xamarin.Forms;
using System.Linq;
namespace Xamarin.Summit
{
    public partial class AgendaPage : TabbedItemPage
    {
        AgendaViewModel ViewModel => (BindingContext as AgendaViewModel);

        public AgendaPage() : base(typeof(AgendaViewModel))
        {
            InitializeComponent();

            var backToFirstItem = new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    var firstItem = ViewModel.TimeLine.FirstOrDefault();
                    if (firstItem != null)
                        TimeLine.ScrollTo(firstItem, ScrollToPosition.Start, true);
                })
            };

            HeaderOne.GestureRecognizers.Add(backToFirstItem);
            HeaderTwo.GestureRecognizers.Add(backToFirstItem);
        }
    }
}
