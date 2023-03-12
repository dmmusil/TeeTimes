namespace TeeTimes.Reservations
{
    public static class Schedule
    {
        public static TeeSheet Today()
        {
            return new TeeSheet(DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
