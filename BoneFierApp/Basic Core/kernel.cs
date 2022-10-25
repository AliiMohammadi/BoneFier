using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier.Basic
{
    internal class kernel
    {
        /// <summary>
        /// تابع کشتن روند
        /// </summary>
        /// <param name="App"></param>
        public static void TerminateApp(string App)
        {
            if (string.IsNullOrWhiteSpace(App))
                return;

            Process[] mainAppProcessOrProcessesRunning = Process.GetProcessesByName(App);

            foreach (var p in mainAppProcessOrProcessesRunning)
            {
                p.Kill();
            }
        }
        /// <summary>
        /// برنامه رو روی حالت ستارت اپ میاره
        /// </summary>
        /// <returns></returns>
        public static bool ChekStartUp(string AppName, string TargetPath)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            bool IsOn = (rkApp.GetValue(AppName) != null);

            if (!IsOn)
            {
                rkApp.SetValue(AppName, TargetPath);
            }

            return IsOn;
        }
    }
}
