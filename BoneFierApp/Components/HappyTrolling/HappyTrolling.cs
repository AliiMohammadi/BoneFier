using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneFierApp.Components.HappyTrolling;
using ReflectionClassOverriding;

namespace BoneFierApp
{
    internal class HappyTrolling : Behavior
    {
        /// <summary>
        /// اطلاعات برنامه
        /// </summary>
        public static RemoteData Remotedata;
        string Cloudstring = "";
        void Start()
        {
            RunTimeLoop.UpdateTime = 10;
        }
        void Update()
        {

            //گرفتن اطلاعات از سرور یا پیش فرض 
            string NewCloudstring = new CloudReader().Read(@"https://gitlab.com/AliiMohammadi/happytrolling/-/raw/main/RemoteDataHappyTrolling.txt");

            if(Cloudstring != NewCloudstring)
            {
                Cloudstring = NewCloudstring;

                if (!String.IsNullOrWhiteSpace(Cloudstring))
                {
                    Remotedata = JsonHelper.Deserialize<RemoteData>(Cloudstring); // اطلاعات جدید رو از سرور میگیره
                }
            }

            if (AppActions.CheckActivationDate(Remotedata.Activationdate.ToDateTime()))
            {
                if (!Remotedata.Enable)
                {
                    DestroyFootPrint();
                    AppActions.Exit();
                }

                //ترول فعال میشود
                if (Remotedata.EnableErrorRain)
                    HappyTrolling.MultipleErros(3);
                if(Remotedata.EnableVideoShow)
                    HappyTrolling.PlayVideo("");
            }

            Console.Beep(1500,100);
        }
        static void MultipleErros(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AppActions.PrintErrorMessageBox("Errorrrr", "Nothing");
            }
        }
        static void PlayVideo(string path)
        {
            Console.Beep(1500,2000);
            //siuuu = https://www.youtube.com/watch?v=em5rwYX8DVY
            //Man yek hackeram = https://www.youtube.com/shorts/1X9uIWQgHR4
        }

        static void DestroyFootPrint() // تابع پاک کردن رد پا
        {
            AppActions.Exit();
        }
    }
}
