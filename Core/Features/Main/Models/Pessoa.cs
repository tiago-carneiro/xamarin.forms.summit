using Realms;

namespace Xamarin.Summit
{
    public class Pessoa : RealmObject, IPessoa
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
    }
}
