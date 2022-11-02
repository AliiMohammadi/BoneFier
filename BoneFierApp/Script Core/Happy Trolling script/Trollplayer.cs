using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Script
{
    public partial class Trollplayer : Form
    {
        public event Action OnVideoEnded;
        bool DisableInputs = true;

        public Trollplayer()
        {
            InitializeComponent();
            SetPlayerConfig();
        }
        void Playvideo() //Video must be wmv format
        {
            axWindowsMediaPlayer1.URL = HappyTrolling.VideoPath;
            Console.WriteLine(HappyTrolling.VideoPath);
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        void SetPlayerConfig()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            axWindowsMediaPlayer1.PlayStateChange += PlayStateChange;
            axWindowsMediaPlayer1.PreviewKeyDown += axWindowsMediaPlayer1_PreviewKeyDown;
            axWindowsMediaPlayer1.MouseUpEvent += axWindowsMediaPlayer1_MouseUpEvent;

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            //TopMost = true;
        }

        void BonefierVideoPlayer_Load(object sender, EventArgs e)
        {
            Playvideo();
        }

        void PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                //Video finished
                Hide();
                OnVideoEnded();
            }
        }

        bool IsActive = false;
        private void axWindowsMediaPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 1000 char send = 11 sec
            // [~92] char = [~1] sec

            if (DisableInputs)
            {
                if (e.Alt) //Disabling ALT
                {
                    if (e.KeyCode == Keys.F4)
                    {
                        if (!IsActive)
                        {
                            IsActive = true;

                            while (true)
                            {
                                double remaing = Math.Floor(axWindowsMediaPlayer1.currentMedia.duration - axWindowsMediaPlayer1.Ctlcontrols.currentPosition);

                                if (remaing <= 0.00)
                                    break;

                                SendKeys.Send("A");

                            }
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
            if (DisableInputs)
                SendKeys.Send("{ESC}"); //disabling mouse clicks

            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
