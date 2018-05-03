using System;

namespace Xamarin.Summit
{
    public class TimeLineResult : TimeLineBase, ITimeLine
    {
        public string Palestrante { get; set; }

        public TimeLineResult()
            => Id = Guid.NewGuid().ToString();
    }
}
