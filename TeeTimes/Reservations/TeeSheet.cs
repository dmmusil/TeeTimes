using System.Collections;

namespace TeeTimes.Reservations
{
    public class TeeSheet : Dictionary<string, TeeTime>
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
            var teeTimes = Enumerable.Repeat(0, 72)
                .Select((_, index) => {
                    DateTime time = date.ToDateTime(TimeOnly.MinValue)
                                        + TimeSpan.FromMinutes(index * 10)
                                        + TimeSpan.FromHours(7);
                    return new TeeTime(time);
                });
            foreach (var teeTime in teeTimes)
            {
                this[teeTime.Time.ToShortTimeString()] = teeTime;
            }
        }

        public DateOnly Date { get; set; }

        public Reservation Reserve(TeeTime teeTime, string name)
        {
            return new Reservation(this, teeTime, name);
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

    public class Reservation
    {
        public Reservation(TeeSheet sheet, TeeTime time, string name)
        {
            Sheet = sheet;
            Time = time;
            Name = name;
        }

        public TeeSheet Sheet { get; }
        public TeeTime Time { get; }
        public string Name { get; }
    }
}
