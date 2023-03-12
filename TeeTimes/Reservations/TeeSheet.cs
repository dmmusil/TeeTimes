using System.Collections;

namespace TeeTimes.Reservations
{
    public class TeeSheet
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
            TeeTimes = Enumerable.Repeat(0, 72)
                .Select((_, index) => 
                new TeeTime(
                    date.ToDateTime(TimeOnly.MinValue) 
                    + TimeSpan.FromMinutes(index * 10) 
                    + TimeSpan.FromHours(7)));
        }

        public DateOnly Date { get; set; }
        public IEnumerable<TeeTime> TeeTimes { get; set; }
        public TeeTime this[string time]
        {
            get
            {
                try
                {
                    return TeeTimes.First(t => TimeOnly.FromDateTime(t.Time) == TimeOnly.Parse(time));
                }
                catch (InvalidOperationException e) when (e.Message.StartsWith("Sequence contains no"))
                {
                    throw new TeeTimeNotFoundException(time, e);
                }
            }
        }
    }

        public class TeeTimeNotFoundException : Exception
        {
            public TeeTimeNotFoundException(string time, InvalidOperationException e) : base($"Tee time not found at {time}", e)
            {
            }
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
