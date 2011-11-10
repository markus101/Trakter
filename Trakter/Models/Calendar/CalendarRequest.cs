namespace Trakter.Models.Calendar
{
    public class CalendarRequest
    {
        //Date in YMD (20110131)
        public string Date { get; set; }

        //Number of days
        public int? Days { get; set; }
    }
}
