using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class EnderecoWrapper
    {
        public int DisplayScreenWidth { get; set; }
        public string Local { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

        public string Mapa => $"https://maps.googleapis.com/maps/api/staticmap?center={Lat},{Lon}&zoom=18&size={DisplayScreenWidth}x400&maptype=roadmap&markers=color:red%7C{Lat},{Lon}";
    }
}
