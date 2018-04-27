using Realms;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Summit
{
    public class Informacao : RealmObject
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

        public IList<Nota> Notas { get; }

        [Backlink(nameof(Pessoa.Informacao))]
        public IQueryable<Pessoa> Organizacao { get; }
    }
}
