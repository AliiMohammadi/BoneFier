using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneFier.Basic
{
    internal class Debuger
    {
        public static void Log(object mess)
        {
            
                Trace.WriteLine(mess);
        }
        public static void Print(object message)
        {
            
                Console.WriteLine(message);
        }
        public static void PrintErrorMessageBox(string message, string Title)
        {
           // MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
