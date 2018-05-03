namespace Xamarin.Summit
{
    public interface IPessoa
    {
        string Id { get; set; }
        string Nome { get; set; }
        string Titulo { get; set; }
        string Descricao { get; set; }
        string Imagem { get; set; }
        string Link { get; set; }
    }

    public abstract class PessoaBase : IPessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
    }
}
