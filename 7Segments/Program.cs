using _7Segments.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Segments
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new frm15DigitScreen());
            Application.Run(new FormTestSevenSegments());

            //Application.Run(new frmTestLCD());
            //////   Application.Run(new Form1TestNew_screen());
            //Application.Run(new Form1());
            //  Application.Run(new frmLCD());

        }
    }
}
