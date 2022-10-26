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
        public Trollplayer()
        {
            InitializeComponent();
            SetPlayerConfig();
        }
        void Playvideo()
        {
            axWindowsMediaPlayer1.URL = HappyTrolling.VideoPath;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        void SetPlayerConfig()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            axWindowsMediaPlayer1.PlayStateChange += PlayStateChange;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
        }

        void BonefierVideoPlayer_Load(object sender, EventArgs e)
        {
            Playvideo();
        }

        void PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Close();
                //Video finished
            }
        }
    }
}
