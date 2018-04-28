using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class AgendaViewModel : ViewModelBase
    {
        public AgendaViewModel() : base(Resource.AgendaTitle)
        {
            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                await InitializeAsync();
            });
        }
    }
}
