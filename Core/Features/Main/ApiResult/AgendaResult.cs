using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class AgendaResult : AgendaBase, IAgenda
    {
        public IEnumerable<TimeLineResult> TimeLine { get; set; }
    }
}
