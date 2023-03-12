using TeeTimes.Reservations;
using static TeeTimes.Reservations.TeeSheet;

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
            for (int i = 0; i < teeTimes.Length - 1; i++)
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

        [Fact]
        public void CanGetTeeTimeByTime()
        {
            Assert.NotNull(teeSheet["7:00"]);
            Assert.NotNull(teeSheet["8:00"]);
            Assert.NotNull(teeSheet["11:00"]);
            Assert.NotNull(teeSheet["18:30"]);

            Assert.Throws<TeeTimeNotFoundException>(() => teeSheet["22:00"]);
        }
    }
}