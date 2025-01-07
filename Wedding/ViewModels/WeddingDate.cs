using System.Globalization;

namespace Wedding.ViewModels {
    public class WeddingDate {

        public WeddingDate(DateTime date) : this(date, CultureInfo.GetCultureInfo("ru-Ru")) { }

        public WeddingDate(DateTime date, CultureInfo cultureInfo) {

            this.date = date;

            DayOfWeek cultureStart = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime first = new DateTime(date.Year, date.Month, 1);

            DayOfWeek = first.DayOfWeek == System.DayOfWeek.Sunday ? 6 : ((int)first.DayOfWeek) - 1;
            CurentDay = date.Day;
            Month = date.ToString("MMMM", cultureInfo);
            CountDay = DateTime.DaysInMonth(date.Year, date.Month);

            CountWeeks = (CountDay + DayOfWeek) / 7;
            if ((CountDay + DayOfWeek) / 7 > 0) {
                CountWeeks++;
            }

            int[] days = new int[CountWeeks * 7];

            int day = 1;
            for (int index = 0; index < days.Length; index++) {
                if (index < DayOfWeek || day > CountDay) {
                    days[index] = -1;
                } else {
                    days[index] = day++;
                }
            }

            Days = days;
            TextValue = date.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        private readonly DateTime date;

        public int DayOfWeek { get; private set; }
        public string Month { get; private set; }
        public int CurentDay { get; private set; }
        public int CountDay { get; private set; }
        public int CountWeeks { get; private set; }
        public IReadOnlyList<int> Days { get; private set; }
        public string TextValue { get; private set; }

        public string ToText(string format) {
            return date.ToString(format);
        }

    }
}
