using BoneFier.Basic;
using ReflectionClassOverriding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoneFier
{
    internal static class RunTimeLoop
    {
        static bool LoopState;

        public static bool LoopActivationState
        {
            get { return LoopState; }
            set { LoopState = value; }
        }
        /// <summary>
        /// Main loop
        /// </summary>
        /// <param name="yeild">loop waiting time in second</param>
        public static void StartLoop(int yeild)
        {
            ReflectionOverriding ObjectCaller = new ReflectionOverriding(System.Reflection.Assembly.GetExecutingAssembly());
            ObjectCaller.SendMessage("Start");

            int milisecUpdatetime = yeild * 1000;
            LoopState = true;
            Debuger.Print("Loop Started.");

            while (LoopState)
            {
                ObjectCaller.SendMessage("Update");

                Thread.Sleep(milisecUpdatetime);
            }
        }
    }
}
