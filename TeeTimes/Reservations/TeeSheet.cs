using System.Collections;

namespace TeeTimes.Reservations
{
    public class TeeSheet : Dictionary<string, TeeTime>
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
            var teeTimes = Enumerable.Range(0, 72)
                .Select(value => {
                    DateTime time = date.ToDateTime(TimeOnly.MinValue)
                                        + TimeSpan.FromMinutes(value * 10)
                                        + TimeSpan.FromHours(7);
                    return new OpenTeeTime(time);
                });
            foreach (var teeTime in teeTimes)
            {
                this[teeTime.Time.ToShortTimeString()] = teeTime;
            }
        }

        public DateOnly Date { get; set; }

        public void Reserve(string time, string name)
        {
            if (this[time] is OpenTeeTime available)
            {
                this[time] = new ReservedTeeTime(available.Time, name);
            }
            else
            {
                throw new Exception();
            }
            
        }
    }

    public abstract class TeeTime
    {
        public TeeTime(DateTime time)
        {
            Time = time;
        }

        public DateTime Time { get; set; }
    }

    public class OpenTeeTime : TeeTime
    {
        public OpenTeeTime(DateTime time) : base(time)
        {
        }
    }

    public class ReservedTeeTime : TeeTime
    {
        public ReservedTeeTime(DateTime time, string name) : base(time)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
