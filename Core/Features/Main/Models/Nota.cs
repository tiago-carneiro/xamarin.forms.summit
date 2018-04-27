using Realms;

namespace Xamarin.Summit
{
    public class Nota : RealmObject
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
