using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Extentions
{
    public static class DateOnlyExtentions
    {
        public static string ToShamsiJustDate(this DateOnly date)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dateTime = new DateTime(date.Year,date.Month,date.Day);
            return pc.GetYear(dateTime) + "/" +
                pc.GetMonth(dateTime).ToString("00") + "/" +
                pc.GetDayOfMonth(dateTime).ToString("00");
        }
    }
}
