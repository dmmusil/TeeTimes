using System.Collections;

namespace TeeTimes.Reservations
{
    public class TeeSheet
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
        }

        public DateOnly Date { get; set; }
        public IEnumerable<TeeTime> TeeTimes { get; set; } = Enumerable.Repeat(new TeeTime(), 72);
    }

    public class TeeTime
    {
        public TeeTime()
        {
        }
    }
}
