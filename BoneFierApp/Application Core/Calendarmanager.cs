using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier
{
    internal class Calendarmanager
    {
        /// <summary>
        /// چک کردن زمان فعال سازی 
        /// </summary>
        /// <param name="Targetdate"></param>
        /// <returns></returns>
        public static bool CheckActivationDate(DateTime Targetdate)
        {
            DateTime now = DateTime.Now;

            return (now.Year >= Targetdate.Year && now.Month >= Targetdate.Month && now.Day >= Targetdate.Day && now.Hour >= Targetdate.Hour && now.Minute >= Targetdate.Minute);
        }
        /// <summary>
        /// چک کردن روز فعال سازی 
        /// </summary>
        /// <param name="Targetdate"></param>
        /// <returns></returns>
        public static bool CheckActivationDay(DateTime Targetdate)
        {
            DateTime now = DateTime.Now;

            return (now.Year >= Targetdate.Year && now.Month >= Targetdate.Month && now.Day >= Targetdate.Day);
        }
    }
}
