using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier
{
    /// <summary>
    /// Application Configuration struct
    /// </summary>
    internal struct AppConfig
    {
        public bool Enable { get; set; }
        public SolidDate Activationdate { get; set; }
        public int LoopFrec { get; set; }

        public AppConfig(bool enabel,SolidDate soliddate , int loopfrec)
        {
            Enable = enabel;
            Activationdate = soliddate; //مشکل تاریخ داریم با سیستم استاد
            LoopFrec = loopfrec;
        }
    }
}
