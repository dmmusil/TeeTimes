using TeeTimes.Reservations;

namespace TeeTimes.Tests
{
    public class TeeSheetTests
    {
        [Fact]
        public void CanGetTodaysTeeSheet()
        {
            TeeSheet teeSheet = Schedule.Today();
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), teeSheet.Date);
        }
    }
}