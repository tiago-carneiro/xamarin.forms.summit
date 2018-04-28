namespace Xamarin.Summit
{
    public interface IInformacao
    {
        string Titulo { get; set; }
        string SubTitulo { get; set; }
        string Descricao { get; set; }
        string Local { get; set; }
        string Lat { get; set; }
        string Lon { get; set; }
    }
    
    public abstract class InformacaoBase : IInformacao
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
