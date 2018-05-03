using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class PalestraWrapper : TimeLineBase, ITimeLine
    {
        public IEnumerable<PalestranteWrapper> Palestrantes { get; set; }
    }
}
