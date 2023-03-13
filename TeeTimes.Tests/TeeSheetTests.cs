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
            Assert.Equal(72, teeSheet.Count);
        }

        [Fact]
        public void TeeTimesAre10MinutesApart()
        {
            var teeTimes = teeSheet.ToArray();
            for (int i = 0; i < teeTimes.Length - 1; i++)
            {
                var teeTime1 = teeTimes[i];
                var teeTime2 = teeTimes[i + 1];
                Assert.Equal(TimeSpan.FromMinutes(10), teeTime2.Value.Time - teeTime1.Value.Time);
            }
        }

        [Fact]
        public void TeeTimesStartAt7am()
        {
            Assert.Equal(
                TimeOnly.FromTimeSpan(TimeSpan.FromHours(7)),
                TimeOnly.FromDateTime(teeSheet.First().Value.Time));
        }

        [Fact]
        public void TheLastTeeTimeIs650pm()
        {
            Assert.Equal(
                TimeOnly.FromTimeSpan(TimeSpan.FromHours(18) + TimeSpan.FromMinutes(50)),
                TimeOnly.FromDateTime(teeSheet.Last().Value.Time));
        }

        [Fact]
        public void CanGetTeeTimeByTime()
        {
            Assert.NotNull(teeSheet["7:00 AM"]);
            Assert.NotNull(teeSheet["8:00 AM"]);
            Assert.NotNull(teeSheet["11:00 AM"]);
            Assert.NotNull(teeSheet["6:30 PM"]);

            Assert.Throws<KeyNotFoundException>(() => teeSheet["7:00 PM"]);
        }

        [Fact]
        public void CanReserveTeeTimeWithName()
        {
            teeSheet.Reserve("7:00 AM", "Dylan");

            ReservedTeeTime reservation = (ReservedTeeTime)teeSheet["7:00 AM"];

            Assert.Equal("Dylan", reservation.Name);
        }

        [Fact]
        public void CanNotReserveAnAlreadyReservedTeeTime()
        {
            teeSheet.Reserve("7:00 AM", "Dylan");

            Assert.Throws<Exception>(() => teeSheet.Reserve("7:00 AM", "Bob"));
        }
    }
}