using System.Collections;

namespace TeeTimes.Reservations
{
    public class TeeSheet
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
            TeeTimes = Enumerable.Repeat(0, 72)
                .Select((value, index) => 
                new TeeTime(
                    date.ToDateTime(TimeOnly.MinValue) 
                    + TimeSpan.FromMinutes(index * 10) 
                    + TimeSpan.FromHours(7)));
        }

        public DateOnly Date { get; set; }
        public IEnumerable<TeeTime> TeeTimes { get; set; }
    }

    public class TeeTime
    {
        public TeeTime(DateTime time)
        {
            Time = time;
        }

        public DateTime Time { get; set; }
    }
}
