using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneFier.Basic;

namespace BoneFier
{
    internal class Application
    {
        public static string ApplicationPath
        {
            get
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                return path.Substring(8);
            }
        }

        public string ConfigFile = "CONF";

        //تنظیمات پیش فرض برنامه:
        public AppConfig ApplicationConfigDEFULT = new AppConfig(true,new SolidDate(2022,10,24,21,15,0),10);
        /// <summary>
        /// تنظیمات برنامه
        /// </summary>
        public AppConfig ApplicationConfig;

        const string CloudConfigLink = @"https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt";

        string Cloudstring = "";
        //گرفتن اطلاعات از سرور یا پیش فرض 
        public void UpdateAppConfig()
        {
            //1: checking server config and Update local config file
            //2: checking local config file 
            //3: Load form program

            try
            {
                string NewCloudstring = new CloudReader().Read(CloudConfigLink);

                if (!String.IsNullOrWhiteSpace(NewCloudstring))
                {
                    if (NewCloudstring != Cloudstring)
                    {
                        Cloudstring = NewCloudstring;
                        ApplicationConfig = JsonHelper.Deserialize<AppConfig>(Cloudstring); // اطلاعات جدید رو از سرور میگیره

                        if (Program.emigrator.IsEmegrated(Program.emigrator.TargetPath))
                        {
                            Program.asset.WriteFile(ConfigFile, Cloudstring);
                        }
                    }
                }
                else
                {
                    if (Program.emigrator.IsEmegrated(Program.emigrator.TargetPath)) //فایل محلی رو میخونه
                    {
                        ApplicationConfig = JsonHelper.Deserialize<AppConfig>(Program.asset.ReadFile(ConfigFile));
                    }
                    else
                    {
                        ApplicationConfig = ApplicationConfigDEFULT; //در غیر اطلاعات پیش فرض رو میگیره
                    }

                    Debuger.PrintWarning("Could not read config data from server.");
                }
            }
            catch (Exception ex)
            {
                ApplicationConfig = ApplicationConfigDEFULT; //در غیر اطلاعات پیش فرض رو میگیره
                Debuger.PrintError("Could not read config data from server or local file. " + ex.Message);
            }

        }

        /// <summary>
        /// خروج استاندارد از برنامه
        /// </summary>
        public static void Exit()
        {
            RunTimeLoop.LoopActivationState = false;
            System.Windows.Forms.Application.Exit();
            Environment.Exit(0);
        }
    }
}
