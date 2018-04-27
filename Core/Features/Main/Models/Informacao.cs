using Realms;
using System.Collections.Generic;

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
        public IList<Pessoa> Organizacao { get; }
    }
}
