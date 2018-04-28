using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class ApoioViewModel : ViewModelBase
    {
        public ApoioViewModel() : base(Resource.ApoioTitle)
        {
            MessagingCenter.Subscribe<MainViewModel, LoadInfoResult>(this, ConstantHelper.ReloadData, async (sender, args) =>
            {
                await InitializeAsync();
            });
        }
    }
}
