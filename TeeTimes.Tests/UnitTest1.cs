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

        [Fact]
        public void TeeSheetHas72Slots()
        {
            TeeSheet teeSheet = Schedule.Today();
            Assert.Equal(72, teeSheet.TeeTimes.Count());
        }
    }
}