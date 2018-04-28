using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class InformacaoWrapper: InformacaoBase, IInformacao
    {
        public IEnumerable<NotaWrapper> Notas { get; set; }
        public IEnumerable<OrganizacaoWrapper> Organizacao { get; set; }
    }
}
