using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneFier.Basic;
using ReflectionClassOverriding;

namespace BoneFier
{
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

            Application.Exit();
        }
    }
}
