using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Player_test
{
    public partial class BonefierVideoPlayer : Form
    {
        bool DisableInputs = true;
        public BonefierVideoPlayer()
        {
            InitializeComponent();
        }
        //TESTING code
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void BonefierVideoPlayer_Load(object sender, EventArgs e)
        {
            Config();

            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        void Config()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //TopMost = true;

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = @"D:/TROLLshowvid.wmv";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Application.Exit();
            }
        }

        private void BonefierVideoPlayer_KeyUp(object sender, KeyEventArgs e)
        {

        }

        bool IsActive = false;
        private void axWindowsMediaPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 1000 char send = 11 sec
            // [~92] char = [~1] sec
            axWindowsMediaPlayer1.Ctlcontrols.play();

            if (false)
            {
                if (e.Alt) //Disabling ALT
                {
                    if (e.KeyCode == Keys.F4)
                    {
                        if (!IsActive)
                        {
                            IsActive = true;

                            while(true)
                            {
                                double remaing = Math.Floor(axWindowsMediaPlayer1.currentMedia.duration - axWindowsMediaPlayer1.Ctlcontrols.currentPosition);

                                if (remaing <= 0.00)
                                    break;

                                SendKeys.Send("A");

                            }
                            Console.WriteLine(Math.Floor(axWindowsMediaPlayer1.currentMedia.duration - axWindowsMediaPlayer1.Ctlcontrols.currentPosition));
                        }
                        IsActive = false;
                    }
                }
                if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin) // Disabling win key
                {
                    if (!IsActive)
                    {
                        IsActive = true;

                        SendKeys.Send("A");
                    }
                    IsActive = false;
                }
            }
        }

        private void axWindowsMediaPlayer1_MouseUpEvent(object sender, AxWMPLib._WMPOCXEvents_MouseUpEvent e)
        {
            if(DisableInputs)
                SendKeys.Send("{ESC}"); //disabling mouse clicks

            axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        private void axWindowsMediaPlayer1_KeyUpEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {

        }

        private void axWindowsMediaPlayer1_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {

        }

        private void BonefierVideoPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
