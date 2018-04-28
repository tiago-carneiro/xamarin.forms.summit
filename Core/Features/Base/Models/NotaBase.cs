namespace Xamarin.Summit
{
    public interface INota
    {
        string Titulo { get; set; }
        string Descricao { get; set; }
    }

    public abstract class NotaBase : INota
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
