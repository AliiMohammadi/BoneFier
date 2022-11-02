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
        public static readonly AppConfig ApplicationConfigDEFULT = new AppConfig(true,new SolidDate(2022, 11, 9, 14, 5, 1), 30); //new SolidDate(2022,11,6,15,30,1)
        /// <summary>
        /// تنظیمات برنامه
        /// </summary>
        public AppConfig ApplicationConfig = ApplicationConfigDEFULT;

        const string CloudConfigLink = @"https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt";

        CloudReader cloud = new CloudReader();
        string Cloudstring = "";
        public bool UseCloudConfig = true;

        //گرفتن اطلاعات از سرور یا پیش فرض 
        public void UpdateAppConfig()
        {

            Debuger.Print("Updating application configuration.");

            //1: checking server config and Update local config file
            //2: checking local config file 
            //3: Load form program

            try
            {
                string NewCloudstring = null;

                if (UseCloudConfig)
                     NewCloudstring = cloud.Read(CloudConfigLink); //اطلاعات رو سرورو میگیره

                if (!String.IsNullOrWhiteSpace(NewCloudstring)) //تشخیص اطلاعات
                {
                    if (NewCloudstring != Cloudstring) //تشخیص اطلاعات جدید
                    {
                        Cloudstring = NewCloudstring;
                        ApplicationConfig = JsonHelper.Deserialize<AppConfig>(Cloudstring); // پیکر بندی اطلاعات جدید

                        if (Program.emigrator.IsEmegrated(Program.emigrator.TargetPath))
                        {
                            WriteConfigFile(Cloudstring); //اپدیت کردن فایل محلی پیکر
                        }
                    }
                }
                else
                {
                    if (Program.emigrator.IsEmegrated(Program.emigrator.TargetPath)) //فایل محلی رو میخونه
                    {
                        if (!Program.asset.Exist(ConfigFile)) //فایل محلی موجود نیست
                        {
                            WriteConfigFile(JsonHelper.Serialize(ApplicationConfigDEFULT)); //ساخت فایل پیکر در صورت موجو نبودن
                            ApplicationConfig = ApplicationConfigDEFULT; // اطلاعات پیش فرض رو میگیره
                        }else
                            ApplicationConfig = JsonHelper.Deserialize<AppConfig>(Program.asset.ReadFile(ConfigFile)); //اطلاعات رو از فایل محلی میگیره
                    }
                    else
                    {
                        ApplicationConfig = ApplicationConfigDEFULT; //در غیر اطلاعات پیش فرض رو میگیره
                    }

                    if(UseCloudConfig)
                        Debuger.PrintWarning("Could not read config data from server.");
                }
            }
            catch (Exception ex)
            {
                ApplicationConfig = ApplicationConfigDEFULT; //در غیر اطلاعات پیش فرض رو میگیره
                Debuger.PrintError("Could not read config data from server or local file. ex: " + ex.Message);
            }

        }

        void WriteConfigFile(string data)
        {
            Program.asset.WriteFile(ConfigFile, data); //اپدیت کردن فایل محلی پیکر
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
