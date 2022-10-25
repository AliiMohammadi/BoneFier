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
        public AppConfig ApplicationConfig;
        public AppConfig ApplicationConfigDEFULT = new AppConfig(true,new SolidDate(2022,10,24,21,15,0),10);

        string Cloudstring = "";
        //گرفتن اطلاعات از سرور یا پیش فرض 
        public void UpdateAppConfig()
        {

            string NewCloudstring = new CloudReader().Read(@"https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt");

            if (!String.IsNullOrWhiteSpace(NewCloudstring))
            {
                if (NewCloudstring != Cloudstring)
                {
                    Cloudstring = NewCloudstring;
                    ApplicationConfig = JsonHelper.Deserialize<AppConfig>(Cloudstring); // اطلاعات جدید رو از سرور میگیره
                }
            }
            else
                ApplicationConfig = ApplicationConfigDEFULT; //در غیر اطلاعات پیش فرض رو میگیره

        }

        public static void Exit()
        {
            RunTimeLoop.LoopActivationState = false;
            System.Windows.Forms.Application.Exit();
            Environment.Exit(0);
        }
    }
}
