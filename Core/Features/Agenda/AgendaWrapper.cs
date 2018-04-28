using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class AgendaWrapper : AgendaBase, IAgenda
    {
        public IEnumerable<TimeLineWrapper> TimeLine { get; set; }
    }
}
