using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace BoneFierApp
{
    public class AppActions
    {
        public string ApplicationName = "BoneFierApp";
        /// <summary>
        /// مسیر رفتن
        /// </summary>
        public string EmigrationPath;
        public string TargetPath;

        public static string ApplicationPath
        {
            get {
                string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                return path.Substring(8);
                }
        }
        /// <summary>
        /// تاریخ فعال شدن
        /// تاریخ پیش فرض تعیین کن
        /// </summary>
        public DateTime ActivationDate = new DateTime(2022,1,1,1,1,1);
        public AppActions()
        {
            EmigrationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TargetPath = EmigrationPath + @"\" + ApplicationName + ".exe";
            ActivationDate = DateTime.Now;
        }
        public AppActions(DateTime activationdate)
        {
            EmigrationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TargetPath = EmigrationPath + @"\" + ApplicationName + ".exe";
            ActivationDate = activationdate;
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
        public void Emigrate(string Destination)
        {
            if (!IsEmegrated(TargetPath))
            {
                try
                {
                    string sourceFile = System.IO.Path.Combine(Path.GetDirectoryName(ApplicationPath), ApplicationName+ ".exe");
                    string destFile = System.IO.Path.Combine(Destination, ApplicationName + ".exe");

                    Directory.CreateDirectory(Destination);

                    File.Copy(sourceFile, destFile, true);

                    Print("Emigrated.");
                    Process.Start(TargetPath);
                    Exit();
                }
                catch (Exception ex)
                {
                    Print("Failed to emigrate : "+ ex.Message);
                }
            }
        }

        /// <summary>
        /// چک کردن تایم دقیق تا دقیقه فعال سازی
        /// </summary>
        /// <param name="Targetdate"></param>
        /// <returns></returns>
        public static bool CheckActivationDate(DateTime Targetdate)
        {
            DateTime now = DateTime.Now;

            return (now.Year >= Targetdate.Year && now.Month >= Targetdate.Month && now.Day >= Targetdate.Day && now.Hour >= Targetdate.Hour && now.Minute >= Targetdate.Minute);
        }
        /// <summary>
        /// چک کردن روز فعال سازی 
        /// </summary>
        /// <param name="Targetdate"></param>
        /// <returns></returns>
        public static bool CheckActivationDay(DateTime Targetdate)
        {
            DateTime now = DateTime.Now;

            return (now.Year >= Targetdate.Year && now.Month >= Targetdate.Month && now.Day >= Targetdate.Day);
        }

        public static void Exit()
        {
            RunTimeLoop.LoopActivationState = false;
            Application.Exit();
        }
        public static void Print(object message)
        {
            Console.WriteLine(message);
        }
        public static void PrintErrorMessageBox(string message,string Title)
        {
            MessageBox.Show(message, Title,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
