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
            return DateTime.Compare(Targetdate, DateTime.Now) <= 0;
        }
        public static bool CheckActivationDay(DateTime Targetdate)
        {
            DateTime now = DateTime.Now;

            if (now.Year < Targetdate.Year)
                return true;
            else if (now.Year == Targetdate.Year)
            {
                if (now.Month < Targetdate.Month)
                    return true;
                else if (now.Month == Targetdate.Month)
                {
                    if(now.Day <= Targetdate.Day)
                        return true;
                    else 
                        return false;
                }
                else 
                    return false;
            }
            else 
                return false;
        }
    }
}
