namespace TeeTimes.Reservations
{
    public class TeeSheet
    {

        public TeeSheet(DateOnly date)
        {
            Date = date;
        }

        public DateOnly Date { get; set; }
    }
}
