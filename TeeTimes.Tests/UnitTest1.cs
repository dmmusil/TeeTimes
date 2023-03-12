using TeeTimes.Reservations;

namespace TeeTimes.Tests
{
    public class TeeSheetTests
    {
        private readonly TeeSheet teeSheet = Schedule.Today();

        [Fact]
        public void CanGetTodaysTeeSheet()
        {
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), teeSheet.Date);
        }

        [Fact]
        public void TeeSheetHas72Slots()
        {
            Assert.Equal(72, teeSheet.TeeTimes.Count());
        }

        [Fact]
        public void TeeTimesAre10MinutesApart()
        {
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
            Assert.Equal(
                TimeOnly.FromTimeSpan(TimeSpan.FromHours(7)),
                TimeOnly.FromDateTime(teeSheet.TeeTimes.First().Time));
        }

        [Fact]
        public void TheLastTeeTimeIs650pm()
        {
            Assert.Equal(
                TimeOnly.FromTimeSpan(TimeSpan.FromHours(18) + TimeSpan.FromMinutes(50)),
                TimeOnly.FromDateTime(teeSheet.TeeTimes.Last().Time));

        }
    }
}