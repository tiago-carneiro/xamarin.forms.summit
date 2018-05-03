namespace Xamarin.Summit
{
    public interface IAgenda
    {
        string Titulo { get; set; }
        string Descricao { get; set; }
    }

    public abstract class AgendaBase : IAgenda
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
