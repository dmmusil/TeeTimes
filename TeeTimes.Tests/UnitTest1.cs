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

        [Fact]
        public void TeeTimesAre10MinutesApart()
        {
            TeeSheet teeSheet = Schedule.Today();
            TeeTime[] teeTimes = teeSheet.TeeTimes.ToArray();
            for (int i = 0; i < teeTimes.Count()-1; i++)
            {
                var teeTime1 = teeTimes[i];
                var teeTime2 = teeTimes[i+1];
                Assert.Equal(TimeSpan.FromMinutes(10), teeTime2.Time - teeTime1.Time);
            }
        }

        [Fact]
        public void TeeTimesStartAt7am()
        {
            TeeSheet teeSheet = Schedule.Today();
            Assert.Equal(
                TimeOnly.FromTimeSpan(TimeSpan.FromHours(7)),
                TimeOnly.FromDateTime(teeSheet.TeeTimes.First().Time));
        }
    }
}