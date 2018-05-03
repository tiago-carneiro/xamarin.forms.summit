namespace Xamarin.Summit
{
    public interface ITimeLine
    {
        string Id { get; set; }
        string Hora { get; set; }
        string Titulo { get; set; }
        string Descricao { get; set; }
    }
    public abstract class TimeLineBase : ITimeLine
    {
        public string Id { get; set; }
        public string Hora { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
