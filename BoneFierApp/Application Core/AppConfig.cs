using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier
{
    internal class AppConfig
    {
        public bool Enable { get; set; }
        public SolidDate Activationdate { get; set; }
        public int LoopFrec { get; set; }

        public AppConfig() 
        {
            Enable = true;//مشکل تاریخ داریم با سیستم استاد
            Activationdate =SolidDate.ToSolidDate(DateTime.Now);
            LoopFrec = 30;
        }
        public AppConfig(bool enabel,SolidDate soliddate , int loopfrec)
        {
            Enable = enabel;//مشکل تاریخ داریم با سیستم استاد
            Activationdate = soliddate;
            LoopFrec = loopfrec;
        }
    }
}
