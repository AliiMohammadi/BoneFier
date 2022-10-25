using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFierApp
{
    /// <summary>
    /// کلاس اطلاعات برنامه ترول شاد.
    /// این کلاس قراره اطلاعاتی که از سرور دریافت میشه رو به خودش پارس کنه.
    /// اگر که اینترنت در دسترس بود.
    /// </summary>
    internal class RemoteData
    {
        public bool Enable { get; set; }
        public ActivationDate Activationdate { get; set; }
        public int LoopFrec { get; set; }
        public bool EnableErrorRain { get; set; }
        public bool EnableVideoShow { get; set; }

        public RemoteData() //اطلاعات پیش فرض
        {
            Enable = true;//مشکل تاریخ داریم با سیستم استاد
            Activationdate = ActivationDate.ToActivationDate(new DateTime(2022,10,24,14,20,3));
            LoopFrec = RunTimeLoop.UpdateTime;
            EnableErrorRain = true;
            EnableVideoShow = true;
        }

    }
    struct ActivationDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public ActivationDate(int year , int month,int day , int hour , int minute , int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;

        }
        public DateTime ToDateTime()
        {
            return new DateTime(Year,Month,Day,Hour,Minute,Second);
        }
        public static ActivationDate ToActivationDate(DateTime dateTime)
        {
            return new ActivationDate(dateTime.Year, dateTime.Month,dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }
}
