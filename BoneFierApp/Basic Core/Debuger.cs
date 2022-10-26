using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoneFier.Basic
{
    /// <summary>
    /// Class for debuging and printing messages
    /// </summary>
    internal class Debuger
    {
        /// <summary>
        /// Shows message on Output console in the IDE.
        /// </summary>
        /// <param name="mess"></param>
        public static void Log(object mess)
        {
            Trace.WriteLine(mess);
        }
        public static void LogError(object mess)
        {
            Trace.TraceError(mess.ToString());
        }
        /// <summary>
        /// Shows the message on the console application
        /// </summary>
        /// <param name="message"></param>
        public static void Print(object message)
        {
            Console.WriteLine(message);
        }
        public static void PrintError(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintWarning(object message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Shows the message on the message box
        /// </summary>
        /// <param name="message"></param>
        /// <param name="Title"></param>
        public static void PrintErrorMessageBox(string message, string Title)
        {
            MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
