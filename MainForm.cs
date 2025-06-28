
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HotkeyPopUp
{
    public partial class MainForm : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN     = 0x0100;
        private static LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        private bool triggered = false;

        public MainForm(){
            InitializeComponent();
            _proc   = HookCallback;
            _hookID = SetHook(_proc);
        }

        protected override void SetVisibleCore(bool value){
            base.SetVisibleCore(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e){
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosing(e);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc){
            using var curProc = System.Diagnostics.Process.GetCurrentProcess();
            using var curMod  = curProc.MainModule!;
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curMod.ModuleName!), 0);
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam){  //Can change what trigers the pop up here.
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN && !triggered){
                triggered = true;
                ShowPopup();
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private void ShowPopup(){
            var popup = new PopupForm();
            popup.Show();

            var timer = new Timer { Interval = 5000 };  // Change the time here for how long the pop up lasts, 1000 = 1 second.
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                popup.Close();
                triggered = false; // allow future triggers.
            };
            timer.Start();
        }

        #region WinAPI
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
}
