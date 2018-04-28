using Realms;
using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class TimeLine : RealmObject, ITimeLine
    {
        public string Hora { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<Pessoa> Palestrantes { get; }
    }
}
