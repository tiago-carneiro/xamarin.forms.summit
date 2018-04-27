using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class AgendaResult
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<TimeLineResult> TimeLine  { get; set; }
    }
}
