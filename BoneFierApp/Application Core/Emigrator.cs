using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneFier.Basic;

namespace BoneFier
{
    /// <summary>
    /// کلاس مهاجرت کردن برنامه به یک مسیری
    /// </summary>
    internal class Emigrator
    {
        public string ApplicationName = "BoneFierApp";
        /// <summary>
        /// مسیر رفتن
        /// </summary>
        public string EmigrationPath;
        public string TargetPath;

        public Emigrator()
        {
            EmigrationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TargetPath = EmigrationPath + @"\" + ApplicationName + ".exe";
        }

        /// <summary>
        /// چک میکند که قبلا برنامه مهاجرت کرده یا خیر
        /// </summary>
        /// <param name="TargetLocation"></param>
        /// <returns></returns>
        public bool IsEmegrated(string TargetLocation)
        {
            return (File.Exists(TargetLocation));
        }
        /// <summary>
        /// فرستادن یک کپی از خود همین برنامه به یک ادرسی
        /// </summary>
        /// <param name="Destination"></param>
        public void Emigrate()
        {
            if (!IsEmegrated(TargetPath))
            {
                try
                {
                    string sourceFile = System.IO.Path.Combine(Path.GetDirectoryName(Application.ApplicationPath), ApplicationName + ".exe");
                    string destFile = System.IO.Path.Combine(EmigrationPath, ApplicationName + ".exe");

                    Directory.CreateDirectory(EmigrationPath);

                    File.Copy(sourceFile, destFile, true);

                    Debuger.Print("Emigrated.");

                    //اجرا برنامه مهاجر و خارج شدن خود برنامه
                    Process.Start(TargetPath); 
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    Debuger.Print("Failed to emigrate : " + ex.Message);
                }
            }
        }
    }
}
