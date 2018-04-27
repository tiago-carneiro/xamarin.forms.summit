using Realms;

namespace Xamarin.Summit
{
    public class Apoio : RealmObject
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public string Categoria { get; set; }
        public int Ordem { get; set; }
    }
}
