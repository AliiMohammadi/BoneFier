using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier.Basic
{
    internal class Kernel
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
        /// <returns>اگر قبلا بوده مقدار درست برمیگرداند</returns>
        public static bool SetStartUp(string AppName, string TargetPath)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            bool IsOn = (rkApp.GetValue(AppName) != null);

            if (!IsOn)
            {
                rkApp.SetValue(AppName, TargetPath);
            }

            return IsOn;
        }
        /// <summary>
        /// برنامه رو از استارت اپ حذف میکنه
        /// </summary>
        /// <returns>اگر قبلا بوده مقدار درست برمیگرداند</returns>
        public static void RemoveStartUp(string AppName)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            bool IsOn = (rkApp.GetValue(AppName) != null);

            if (!IsOn)
            {
                return;
            }

            rkApp.DeleteValue(AppName);
        }

        public static FileInfo CopyFile(string FilePath, string Destination)
        {
            return CopyFile(FilePath, Path.GetFileName(FilePath),Destination);
        }
        public static FileInfo CopyFile(string FilePath, string newname, string Destination)
        {

            if (!File.Exists(FilePath))
                return null;


            string sourceFile = Path.Combine(Path.GetDirectoryName(FilePath), newname);
            string destFile = Path.Combine(Destination, newname);

            Directory.CreateDirectory(Destination);

            File.Copy(sourceFile, destFile, true);
            return new FileInfo(destFile);
        }
        public static void DeletFile(string path)
        {
            if (!File.Exists(path))
                return;

            File.Delete(path);
        }
        public static void Change3DatesFile(string path,DateTime date)
        {
            if(!File.Exists(path))
                return ;

            File.SetCreationTime(path, date);
            File.SetLastAccessTime(path, date);
            File.SetLastWriteTime(path, date);
        }    
        public static void Change3DatesDirectory(string path, DateTime date)
        {
            if (!Directory.Exists(path))
                return;

            Directory.SetCreationTime(path, date);
            Directory.SetLastAccessTime(path, date);
            Directory.SetLastWriteTime(path, date);
        }
        public static void ZipDirectory(string TargetDir,string ZipDir)
        {
            ZipDirectory(TargetDir, TargetDir + ".zip");
        }
        public static void ZipDirectory(string Targetdir , string ZipDir , string Filename)
        {
            ZipDirectory(Targetdir,ZipDir,Filename,null);
        }
        public static void ZipDirectory(string Targetdir, string ZipDir, string Filename, System.IO.Compression.CompressionLevel level)
        {
            //THANKS TO THE SCRIPTKID

            if (!Directory.Exists(Targetdir))
                return;

            System.IO.Compression.ZipFile.CreateFromDirectory(Targetdir, ZipDir + Filename, level,false);
        }

    }

}
