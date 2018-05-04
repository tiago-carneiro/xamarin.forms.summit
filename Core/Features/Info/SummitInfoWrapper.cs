namespace Xamarin.Summit
{
    public enum SummitInfoType
    {
        Endereco,
        Nota,
        Organizacao
    }

    public class SummitInfoWrapper
    {
        public SummitInfoType Tipo { get; set; }

        public object Dados { get; set; }
    }
}
