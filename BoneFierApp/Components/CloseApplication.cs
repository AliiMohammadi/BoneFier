using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionClassOverriding;

namespace BoneFierApp
{
    internal class CloseApplication 
    {
        public static string AppName = "devenv";
        void Update()
        {
            
            //This is what going to happen:
            if(Program.Debug)
                Console.Beep(1500, 100);

            S_Actions.TerminateApp(AppName);
            AppActions.PrintErrorMessageBox("The '" + AppName + "' has been stoped.", "" + AppName + " Error.");
        }
    }
}
