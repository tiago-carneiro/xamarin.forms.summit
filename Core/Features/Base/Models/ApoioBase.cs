namespace Xamarin.Summit
{
    public interface IApoio
    {
        string Nome { get; set; }
        string Imagem { get; set; }
        string Link { get; set; }
        string Categoria { get; set; }
        int Ordem { get; set; }
    }

    public abstract class ApoioBase : IApoio
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public string Categoria { get; set; }
        public int Ordem { get; set; }
    }
}
