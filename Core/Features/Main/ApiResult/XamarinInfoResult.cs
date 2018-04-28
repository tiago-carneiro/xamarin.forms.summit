using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class XamarinInfoResult
    {
        public string DataAtualizacao { get; set; }
        public InformacoesResult Informacoes { get; set; }
        public IEnumerable<ApoioResult> Apoio { get; set; }
        public IEnumerable<PessoaResult> Pessoas { get; set; }
        public IEnumerable<AgendaResult> Agenda { get; set; }
    }
}
