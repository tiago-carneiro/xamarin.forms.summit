using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class InformacoesResult : InformacaoBase, IInformacao
    {
        public IEnumerable<string> Organizacao { get; set; }
        public IEnumerable<NotaResult> Notas { get; set; }
    }
}
