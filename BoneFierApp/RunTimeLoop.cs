using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionClassOverriding;

namespace BoneFierApp
{
    internal class RunTimeLoop
    {   
        /// <summary>
        /// Loop update frequensy in second
        /// </summary>
        public static int UpdateTime = 30;//In sec
        static bool LoopState;
        public static bool LoopActivationState
        {
            get { return LoopState; }
            set { LoopState = value; }
        }

        public static void StartLoop()
        {
            ReflectionOverriding ObjectCaller = new ReflectionOverriding(System.Reflection.Assembly.GetExecutingAssembly());
            ObjectCaller.SendMessage("Start");

            int milisecUpdatetime = UpdateTime * 1000;
            LoopState = true;

            while (LoopState)
            {
                ObjectCaller.SendMessage("Update");

                System.Threading.Thread.Sleep(milisecUpdatetime);
            }
        }
    }
}
