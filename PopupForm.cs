
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotkeyPopUp
{
    public class PopupForm : Form
    {
        public PopupForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition   = FormStartPosition.CenterScreen;
            TopMost         = true;
            BackColor       = Color.Black;
            Opacity         = 0.9;
            Width           = Screen.PrimaryScreen.Bounds.Width;
            Height          = Screen.PrimaryScreen.Bounds.Height;
            ShowInTaskbar   = false;

            var lbl = new Label
            {
                Text      = "Boo!",    // Change the text of the pop up.
                ForeColor = Color.White,    // Change color of the pop up
                Font      = new Font("Segoe UI", 72, FontStyle.Bold),
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Fill
            };

            Controls.Add(lbl);

            Load += (s, e) =>
            {
                BringToFront();
                Activate();
            };
        }
    }
}
