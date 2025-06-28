
using System;
using System.Media;
using System.Windows.Forms;

namespace HotkeyPopUp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // subtle startup sound, only plays when app is first turned on to let you know it is working now, does not play everytime pop up is activated. 
            SystemSounds.Asterisk.Play();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
