using Realms;

namespace Xamarin.Summit
{
    public class Apoio : RealmObject, IApoio
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public string Categoria { get; set; }
        public int Ordem { get; set; }
    }
}
