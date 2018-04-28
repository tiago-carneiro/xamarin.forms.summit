namespace Xamarin.Summit
{
    public interface IPessoa
    {
        string Nome { get; set; }
        string Titulo { get; set; }
        string Descricao { get; set; }
        string Imagem { get; set; }
        string Link { get; set; }
    }

    public class PessoaBase : IPessoa
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
    }
}
